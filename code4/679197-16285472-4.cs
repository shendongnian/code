    private static readonly object _syncLock = new object();
    private static void write_history(int index, int time_in_sec, int[] sent_resources)
    {
       lock(_syncLock)
       {
            string filepath = "Config\\xxx.txt";
            int writing_index = 0;
            if (File.Exists(filepath))
            {
                System.Threading.Thread.Sleep(5000);
                string temp = File.ReadAllText(filepath);
                for (int i = 0; i < 20; i++)
                {
                    if (temp.IndexOf("<hst_" + i.ToString() + ">") == -1)
                    {
                        writing_index = i;
                        break;
                    }
                }
            }
            System.Threading.Thread.Sleep(5000);
            // write to the file
            File.WriteAllText(filepath, "<hst_" + writing_index.ToString() + ">" + DateTime.Now.AddSeconds(time_in_sec).ToString() + "|" + sent_resources[0] + "|" + sent_resources[1] + "|" + sent_resources[2] + "|" + sent_resources[3] + "</hst_" + writing_index.ToString() + ">");
        }
     }
