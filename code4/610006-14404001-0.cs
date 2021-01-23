    using (var reader = new StreamReader(new FileStream(clientFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
                {
                    var ser = new XmlSerializer(typeof(ClientList));
                    var temp = (ClientList)ser.Deserialize(reader);
                    foreach (var client in temp.Items)
                    {
                        if(clientWatchers.Any(c => c.Handle == client.Handle))
                        {
                            var c = clientWatchers.First(w => w.Handle == client.Handle);
                            c.SyncNumber = client.SyncNumber;
                            c.PsNumber = client.PsNumber;
                            c.IsHalted = client.IsHalted;
                        }
                        else
                        {
                            clientWatchers.Add(client);
                        }
                    }
                    var handles = clientWatchers.Select(c => c.Handle).ToArray();
                    foreach (var handle in handles)
                    {
                        if(temp.Items.All(c => c.Handle != handle))
                            clientWatchers.Remove(clientWatchers.First(c => c.Handle == handle));
                    }
                    //foreach (var client in temp.Items)
                        //clientWatchers.Add(client);
                    dgClientView.DataSource = clientWatchers;
                }
