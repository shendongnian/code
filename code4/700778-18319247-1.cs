    public void objContext_SavingChanges(object sender, EventArgs e)
        {
            var commandText = new StringBuilder();
            var conn = sender.GetType()
                 .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                 .Where(p => p.Name == "Connection")
                 .Select(p => p.GetValue(sender, null))
                 .SingleOrDefault();
            var entityConn = (EntityConnection)conn;
            var objStateManager = (ObjectStateManager)sender.GetType()
                  .GetProperty("ObjectStateManager", BindingFlags.Instance | BindingFlags.Public)
                  .GetValue(sender, null);
            var workspace = entityConn.GetMetadataWorkspace();
            var translatorT =
                sender.GetType().Assembly.GetType("System.Data.Mapping.Update.Internal.UpdateTranslator");
            
            var translator = Activator.CreateInstance(translatorT, BindingFlags.Instance |
                BindingFlags.NonPublic, null, new object[] {objStateManager,workspace,
                entityConn,entityConn.ConnectionTimeout }, CultureInfo.InvariantCulture);
            var produceCommands = translator.GetType().GetMethod(
                "ProduceCommands", BindingFlags.NonPublic | BindingFlags.Instance);
            var commands = (IEnumerable<object>)produceCommands.Invoke(translator, null);
            foreach (var cmd in commands)
            {
                var identifierValues = new Dictionary<int, object>();
                var dcmd =
                    (DbCommand)cmd.GetType()
                       .GetMethod("CreateCommand", BindingFlags.Instance | BindingFlags.NonPublic)
                       .Invoke(cmd, new[] { translator, identifierValues });
                foreach (DbParameter param in dcmd.Parameters)
                {
                    var sqlParam = (SqlParameter)param;
                    commandText.AppendLine(String.Format("declare {0} {1} {2}",
                                                            sqlParam.ParameterName,
                                                            sqlParam.SqlDbType.ToString().ToLower(),
                                                            sqlParam.Size > 0 ? "(" + sqlParam.Size + ")" : ""));
                    commandText.AppendLine(String.Format("set {0} = '{1}'", sqlParam.ParameterName, sqlParam.SqlValue));
                }
                commandText.AppendLine();
                commandText.AppendLine(dcmd.CommandText);
                commandText.AppendLine("go");
                commandText.AppendLine();
            }
            System.Diagnostics.Debug.Write(commandText.ToString());
        }
