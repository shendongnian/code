    private void fnc (object sender, RoutedEventArgs e)
    {
        MyWindow nw = new MyWindow();
    
        nw.Show();
    
        // inline
        nw.Closed += (s1, e1) => Debug.WriteLine("Closed");
        // or
        nw.Closed += (s1, e1) =>
                            {
                                Debug.WriteLine("Closed");
                            };
        // or
        w.Closed += OnWindowClosed;
    }
    private void OnWindowClosed(object s, EventArgs e)
    {
        Debug.WriteLine("Closed");
    }
