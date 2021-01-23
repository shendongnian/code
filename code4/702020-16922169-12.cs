       private void btnStart_Click(object sender, EventArgs e)
        {
            Progress ucProgress = null;
            Dictionary<string, string> dicList = new Dictionary<string, string>();
            dicList.Add("GB", "conn1");
            dicList.Add("US", "conn2");
            dicList.Add("DE", "conn3");
            fpPanel.Controls.Clear();
            Func<KeyValuePair<string, string>, object> createProgress = entry =>
            {
                var tmp = new Progress {Country = entry.Key, DBConnection = entry.Value};
                fpPanel.Controls.Add(tmp);
                return tmp;
            };
            Task.Factory.StartNew(() =>
            {
                //foreach (KeyValuePair<string, string> entry in dicList)
                
                Parallel.ForEach(dicList,
                    entry =>
                    {
                        
                        //create and add the Progress in UI thread
                        var ucProgress = (Progress)fpPanel.Invoke(createProgress, entry);
                        //execute ucProgress.Process(); in non-UI thread in parallel. 
                        //the .Process(); must update UI by using *Invoke
                        ucProgress.Process();
                                                         
                        System.Threading.Thread.SpinWait(5000000);
                    });
            });
        }
