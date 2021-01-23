        while (bWaiting == true)
        {
            //System.Windows.Forms.Application.DoEvents();  // i comment it because i cant find equivalent in WPF
            System.Threading.Thread.Sleep(15);
        }
