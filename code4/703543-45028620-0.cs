    private void log(string text)
            {
                string dd = DateTime.Now.ToString("yyyy-MM-dd");
                string mm = DateTime.Now.ToString("ddd");
    
                if (File.Exists("debug-" + mm + ".txt"))
                {
                    String contents = File.ReadAllText("debug-" + mm + ".txt");
    
    
                    if (!contents.Contains("Date: " + dd))
                    {
                        File.Delete("debug-" + mm + ".txt");
                    }
                }
    
                File.AppendAllText("debug-" + mm + ".txt", "\r\nDate: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:s") + " =>\t" + new System.Diagnostics.StackFrame(1, true).GetMethod().Name + "\t" + text);
    
            }
