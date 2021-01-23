    public delegate void SetListDelegate<T>(List<T> l );
    public void SetList<T> (List<T> l)
    {
        if ( lstW.InvokeRequired)
            lstW.Invoke(new SetListDelegate<T>(SetList<T>), l);
        else
            lstW.Items.AddRange(l);
    }
