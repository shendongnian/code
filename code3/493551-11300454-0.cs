    private static void print(StreamWriter sw, string mlog = "Write here", bool screen = false)
        {
            DateTime ts = DateTime.Now;
            sw.WriteLine(ts + " " + mlog);
            if (screen == true)
            {
                Console.WriteLine(mlog);
            }
        }
