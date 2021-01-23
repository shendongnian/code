    var usersTableAdapter = new testDataSetTableAdapters.usersTableAdapter();
                
                
                usersTableAdapter.Insert(4, "home", "origin", "email@host.com", "realname", "spec", 1, "username", "usernick", "whereform");
                var cmd = usersTableAdapter.Adapter.InsertCommand;
                var text = cmd.CommandText;
                var sb = new StringBuilder(text);
                foreach (SqlParameter cmdParam in cmd.Parameters)
                {
                    if (cmdParam.Value is string)
                        sb.Replace(cmdParam.ParameterName, string.Format("'{0}'", cmdParam.Value));
                    else
                        sb.Replace(cmdParam.ParameterName, cmdParam.Value.ToString());
                }
                Console.WriteLine(sb.ToString());
