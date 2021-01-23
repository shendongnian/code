    System.Threading.Tasks.Task.Factory.StartNew(() => {
        while (true) {
            System.IntPtr hWndCharmBar = FindWindowByCaption(System.IntPtr.Zero, "Charm Bar");
            ShowWindow(hWndCharmBar, 0);
            System.Threading.Thread.Sleep(100); // sleep for a bit
        }
    });
