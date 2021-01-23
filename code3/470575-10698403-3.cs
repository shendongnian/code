    void RemoveHotKey(Control Ctrl, int KeyIndex)
    {
        ContentControl contentCtrl = Ctrl as ContentControl;
        if (contentCtrl != null && contentCtrl.Content != null)
        {
            if (contentCtrl.Content.ToString().Substring(KeyIndex, 1) == "_")
            { 
                contentCtrl.Content = contentCtrl.Content.ToString().Remove(KeyIndex, 1);
            }
        } 
    }
