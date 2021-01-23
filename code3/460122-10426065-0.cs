                    Pipeline pipeLine = rsRemoteRunspace.CreatePipeline();
                    Command myCommand = new Command("Get-Mailbox");
                    myCommand.Parameters.Add("Server", Server);
                    pipeLine.Commands.Clear();
                    pipeLine.Commands.Add(myCommand);
                    Mailboxes = pipeLine.Invoke();
                    foreach (PSObject obj in Mailboxes)
                    {
                        if (mbCount.ContainsKey(obj.Members["Database"].Value.ToString()))
                        {
                            mbCount[obj.Members["Database"].Value.ToString()] += 1;
                        }
                        else
                        {
                            mbCount.Add(obj.Members["Database"].Value.ToString(), 1);
                        }
                    }
                    pipeLine = null;
                }
                foreach (String Database in mbCount.Keys)
                {
                    Console.WriteLine("Database : " + Database + " Mailboxes : " + mbCount[Database].ToString());
                }
