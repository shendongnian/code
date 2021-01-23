    List<Key> keys = new List<Key>();
    void KListener_KeyDown(object sender, RawKeyEventArgs args)
    {
       SetKeyDown(args.key);
       if(IsKeyDown(Key.LeftCtrl) && IsKeyDown(Key.C))
           MessageBox.Show("Woot!");
    }
    void KListener_KeyUp(object sender, RawKeyEventArgs args)
    {
        SetKeyUp(args.key);
    }
    private bool IsKeyDown(Key key)
    {
        return keys.Contains(key);
    }
    private void SetKeyDown(Key key)
    {
        if(!keys.ContainsKey(key)) 
            keys.Add(key);
    }
    private void SetKeyUp(Key key)
    {
        if(keys.ContainsKey(key)) 
            keys.Remove(key);
    }
