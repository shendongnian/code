            StoredDBConnectionManager storedDbConnectionManager = new StoredDBConnectionManager(Properties.Settings.Default.app_dbPassword);
            List<string> connections = storedDbConnectionManager.getStoredConnections();
            foreach (string connection in connections)
            {
                var mi = new MenuItem()
                {
                    Header = connection,
                };
                mi.Click += ConnectionMenuItemClicked;
                mnuFileDBConnections.Items.Add(mi);
            }
