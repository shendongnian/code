    public virtual void OnChanged(ChangeEventArgs e)
    {
        if( Changed != null )
        {
            Changed(this, Convert(e));
        }
    }
