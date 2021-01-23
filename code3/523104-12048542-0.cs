    private void setevent()
    {
        webBrowserForPrinting.DocumentCompleted +=
            new WebBrowserDocumentCompletedEventHandler(NavigateTo);
    
    }
    
    private void NavigateTo(object sender,
        WebBrowserDocumentCompletedEventArgs e)
    {
       //Pause thread as per the need.
       if(dg_parameters.Rows.Count!=1)
            {
                for (int i = 0; i < dg_parameters.Rows.Count-1; i++)
                {
                    string row = "";
                    string cell = "";
                    for (int j = 0; j < dg_parameters.Columns.Count; j++)
                    {
                        cell = cell + dg_parameters.Rows[i].Cells[j].Value;
                        cell = cell + "@";
                        row = cell;
                    }
                    string uri = webBrowser1.Url + row;
                    webBrowser1.Navigate(uri);
                }
            }
    }
