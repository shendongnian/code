                StreamWriter log;
                string fpath = string.Format(@"{0}\{1}.txt",GetDirectory(),DateTime.Now.ToString("yyy-MM-dd"));
                if (!File.Exists(fpath))
                {
                    log = new StreamWriter(fpath);
                }
                else
                {
                    log = File.AppendText(fpath);
                }
                log.WriteLine(string.Format("{0} ==> {1}",DateTime.Now.ToString("MM/dd/yyy HH:mm:ss"), Message));
                log.Dispose();
                log = null;
