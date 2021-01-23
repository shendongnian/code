    System.Threading.Thread t = new System.Threading.Thread(() =>
    {
        yourWebBrowser.Navigate("http://Google.com");
    });
    t.ApartmentState = System.Threading.ApartmentState.STA;
    t.Start();
