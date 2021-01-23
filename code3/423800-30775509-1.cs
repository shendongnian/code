    public async Task<bool> Restore(string backupFile, string databaseName, IProgress<int> progress, CancellationToken ct)
    {
        Restore sqlRestore = null;
        bool result = await Task.Run(() =>
        {
            try
            {
                var deviceItem = new BackupDeviceItem(backupFile, DeviceType.File);
                sqlRestore = new Restore
                {
                    Action = RestoreActionType.Database,
                    Database = databaseName,
                    Partial = false,
                    ReplaceDatabase = true,
                    PercentCompleteNotification = 1
                };
                sqlRestore.PercentComplete += (s, e) => progress.Report(e.Percent);
                sqlRestore.Devices.Add(deviceItem);
                if (_server.Databases[databaseName] != null)
                    _server.KillAllProcesses(databaseName);
                sqlRestore.SqlRestoreAsync(_server);
                while (sqlRestore.AsyncStatus.ExecutionStatus == ExecutionStatus.InProgress)
                {
                    ct.ThrowIfCancellationRequested();
                    Thread.Sleep(500);
                }
                if (sqlRestore.AsyncStatus.ExecutionStatus == ExecutionStatus.Succeeded)
                {
                    Database db = _server.Databases[databaseName];
                    if (db != null)
                        db.SetOnline();
                    _server.Refresh();
                    return true;
                }
                return false;
            }
            catch (OperationCanceledException)
            {
                sqlRestore.Abort();
                sqlRestore.Wait();
                Database db = _server.Databases[databaseName];
                if (db != null)
                    db.Drop();
                return true;
            }
            catch (ConnectionFailureException)
            {
                return false;
            }
            catch (Exception ex)
            {
                _server.KillDatabase(databaseName);
                return false;
            }
        }, ct);
        return result;
    }
