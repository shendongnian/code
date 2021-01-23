    Public Sub BackupDatabase(databaseName As String, backupFileFullPath As String, optionsBackup As OptionsBackupDatabase, operationProgress As IProgress(Of Integer),
                              operationResult As Action(Of OperationResult)) Implements IDatabaseManager.BackupDatabase
        Dim sqlBackup As New Smo.Backup()
        sqlBackup.Action = Smo.BackupActionType.Database
        sqlBackup.BackupSetName = databaseName & " Backup"
        sqlBackup.BackupSetDescription = "Full Backup of " & databaseName
        sqlBackup.Database = databaseName
        Dim bkDevice As New Smo.BackupDeviceItem(backupFileFullPath, Smo.DeviceType.File)
        sqlBackup.Devices.Add(bkDevice)
        sqlBackup.Initialize = optionsBackup.Overwrite
        sqlBackup.Initialize = True
        sqlBackup.PercentCompleteNotification = 5
        AddHandler sqlBackup.PercentComplete, Sub(sender As Object, e As PercentCompleteEventArgs)
                                                  operationProgress.Report(e.Percent)
                                              End Sub
        AddHandler sqlBackup.Complete, Sub(sender As Object, e As ServerMessageEventArgs)
                                           Dim sqlMessage As SqlClient.SqlError = e.Error
                                           Dim opResult As New OperationResult()
                                           Select Case sqlMessage.Number
                                               Case 3014
                                                   opResult.operationResultType = OperationResultType.SmoSuccess
                                                   opResult.message = "Backup successfully created at " & backupFileFullPath & ". " & sqlMessage.Number & ": " & sqlMessage.Message
                                               Case Else
                                                   opResult.operationResultType = OperationResultType.SmoError
                                                   opResult.message = "ERROR CODE " & sqlMessage.Number & ": " & sqlMessage.Message
                                           End Select
                                           operationResult.Invoke(opResult)
                                       End Sub
        AddHandler sqlBackup.NextMedia, Sub(sender As Object, e As ServerMessageEventArgs)
                                            Dim sqlMessage As SqlClient.SqlError = e.Error
                                            Dim opResult As New OperationResult()
                                            opResult.operationResultType = OperationResultType.SmoError
                                            opResult.message = "ERROR CODE:  " & sqlMessage.Number & ": " & sqlMessage.Message
                                            operationResult.Invoke(opResult)
                                        End Sub
        AddHandler sqlBackup.Information, Sub(sender As Object, e As ServerMessageEventArgs)
                                              Dim sqlMessage As SqlClient.SqlError = e.Error
                                              Dim opResult As New OperationResult()
                                              Select Case sqlMessage.Number
                                                  Case 4035
                                                      opResult.operationResultType = OperationResultType.SmoInformation
                                                      opResult.message = sqlMessage.Number & ": " & sqlMessage.Message
                                                  Case Else
                                                      opResult.operationResultType = OperationResultType.SmoError
                                                      opResult.message = "ERROR CODE " & sqlMessage.Number & ": " & sqlMessage.Message
                                              End Select
                                              operationResult.Invoke(opResult)
                                          End Sub
        Try
            sqlBackup.SqlBackupAsync(smoServer)
        Catch ex As Exception
            Throw New BackupManagerException("Error backing up database " & databaseName, ex)
        End Try
    End Sub
