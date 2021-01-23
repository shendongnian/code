        private void playVideo(string file)
        {
            int tc6 = 0;
            try
            {
                axWMPn[0].URL = file;
            }
            catch (System.Runtime.InteropServices.COMException comEx)
            {
                Console.WriteLine("playVideo COMException 0: " + comEx.Source + "  -- " + comEx.Message);
            }
