       private void btnStart_Click(object sender, EventArgs e)
        {
            Progress ucProgress = null;
            Dictionary<string, string> dicList = new Dictionary<string, string>();
            dicList.Add("GB", "conn1");
            dicList.Add("US", "conn2");
            dicList.Add("DE", "conn3");
            fpPanel.Controls.Clear();
            Task.Factory.StartNew(() =>
            {
                //foreach (KeyValuePair<string, string> entry in dicList)
                
                Parallel.ForEach(dicList,
                    entry =>
                    {
                        Func<object> create = () =>
                        {
                                         
                            var tmp = new Progress 
                            {
                                Country = entry.Key, 
                                DBConnection = entry.Value
                            };
                            fpPanel.Controls.Add(tmp);
                            return tmp;
                        };
                        //create and add the Progress from UI thread
                        var ucProgress = (Progress)fpPanel.Invoke(create);
                        //execute ucProgress.Process(); from non-UI thread in parallel. 
                        //the .Process(); must update UI by using *Invoke
                        ucProgress.Process();
                                 
                        //fpPanel.Controls.Add(ucProgress);
                        System.Threading.Thread.SpinWait(5000000);
                    });
            });
        }
