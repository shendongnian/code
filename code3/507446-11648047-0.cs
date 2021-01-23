    private void DoStuff(string documentName)
    {
        Action a = () => 
        {
            var result = ParseFile(documentName);
            Action b = () => 
            {
                TextBox1.Text = result;
            };
            Dispatcher.BeginInvoke(b);
        };
        a.BeginInvoke(callback => 
        {
            a.EndInvoke(callback);
        }, null);
    }
