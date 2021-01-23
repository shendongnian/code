        while (bw.IsBusy)
        {
            Application.DoEvents();
            System.Threading.Thread.Sleep(100);
        }
