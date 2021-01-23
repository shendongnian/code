    Stack<Uri> history= new Stack<Uri>();
    Uri current = null; 
    private void WebBrowser_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
    {
        Uri previous = null;           
        if (history.Count > 0)
            previous = history.Peek();
        // This assumption is NOT always right. 
        // if the page had a forward reference that creates a loop (e.g. A->B->A ), 
        // we would not detect it, we assume it is an A -> B -> back () 
        if (e.Uri == previous)
        {
            history.Pop();                     
        }
        else
        {
            if (current != null)
                history.Push(current);                          
        }
        current = e.Uri; 
    }
