    timer1.Stop();
            Task<Boolean>.Factory.StartNew(() =>
                {
                    DataSet t = new DataSet();
                    //_dataSet1.Reset();
                    Boolean ok = false;
                    Int16 retries = 0;
                    while (!ok && retries<3)
                    try
                    {
                        da.Fill(t);
                        ok = true;
                    }
                    catch
                    {
                        retries++;
                        Thread.Sleep(1000);
                    }
                    //if (!ok) throw new Exception("DB error");
                    if (!ok) return false;
                    try
                    {
                        if (t.Tables.Count > 0 && t.Tables[0].Rows.Count != _lastcount)
                        {
                            _dataSet1 = t;
                            _lastcount = t.Tables[0].Rows.Count;
                            return true;
                        }
                    }
                    catch {  }
                    return false;
                }).ContinueWith(task =>
                    {
                        if (task.IsFaulted)
                        {
                            SQLFailed();
                            return;
                        }
                        if (!task.Result) return;
                        
                        Invoke((Action) (() =>
                                             {
                                                 dataGridView1.DataSource = _dataSet1.Tables[0];
                                                 dataGridView1.Columns[0].Visible = false;
                                                 dataGridView1.Columns[1].Width = 50;
                                             }));
                        
                        if (_lastcount == 0)
                        {
                            NotifyWithMessage("The items have been cleared", "Items cleared");
                        }
                        else
                        {
                            NotifyWithMessage(String.Format("There are {0} new items in your monitor", _lastcount));
                        }
                    });
            
        timer1.Start();
