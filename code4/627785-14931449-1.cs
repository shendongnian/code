         string commandString = string.Format("SELECT [Id] FROM [dbo].[Tech]");
         command = new SqlCommand(commandString, connection);
        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            SqlDependency dependency = (SqlDependency)sender;
            dependency.OnChange -= dependency_OnChange;
            this.Dispatcher.Invoke((System.Action)(() =>
            {
                
                if (e.Info.ToString().ToLower().Trim() == "insert")
                {
                    GetData();
                    int NewTechID = TechIDs.Last();
                }
            }));
        }
        private void GetData()
        {
            command.Notification = null;
            SqlDependency dependency = new SqlDependency(command);
            dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);
            command.Connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    TechIDs.add(int.Parse(reader.GetValue(0).ToString()));
                }
                reader.Close();
            }
            command.Connection.Close();
        }
