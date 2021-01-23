    System.Threading.Thread t = new System.Threading.Thread(() =>
    {
        WebBrowser.Navigate("http://Google.com");
    });
    t.ApartmentState = System.Threading.ApartmentState.STA;
    t.Start();
