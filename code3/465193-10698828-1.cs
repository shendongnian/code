    //<summary>
    //Function to Append a HotKeyChar to a Content of a Control.
    //</summary>
    void AppendHotKeyChar(ContentControl Ctrl, int KeyIndex)
    {
        if (Ctrl.Content.ToString().Substring(KeyIndex, 1) != "_")
        {
            Ctrl.Content = "_" + Ctrl.Content;
        }
    }
    //<summary>
    //Function to Remove a HotKeyChar to a Content of a Control.
    //</summary>
    void RemoveHotKeyChar(ContentControl Ctrl, int KeyIndex)
    {
        if (Ctrl.Content.ToString().Substring(KeyIndex, 1) == "_")
        {
            Ctrl.Content = Ctrl.Content.ToString().Remove(KeyIndex, 1);
        }
    }
