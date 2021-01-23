        public void ReadFile(string filepath)
        {
            Dictionary<string, string> mypaths = new Dictionary<string, string>();
            string line;
            string line1 = null;
            string line2 = null;
            bool store = false;
            using(var rdr = new StreamReader(filepath))
            {
                while((line = rdr.ReadLine()) != null)
                {
                    if(store = false && line.ToLower().Contains("source path:"))
                    {
                        line1 = line;
                        store = true;
                    }
                    else if (store = true && line.ToLower().Contains("destination path:"))
                    {
                        line2 = line;
                    }
                    else if (line.ToLower().Contains("last folder updated:"))
                    {
                        var myvaluetoinspect = line;
                        if(1==1) // my condition
                        {
                            mypaths.Add(line1, line2);
                        }
                        // Clear and start over
                        store = false;
                        line1 = null;
                        line2 = null;
                    }
                    else
                    {
                        store = false;
                        line1 = null;
                        line2 = null;
                    }
                }
            }
        }
