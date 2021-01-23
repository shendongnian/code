    public bool? SelectedAll
    {
        get { return this.Get<bool?>("SelectedAll"); }
        set 
        {
            if(Equals(SelectedAll, value) == true)
                return;
            this.Set<bool?>("SelectedAll", value);
            OnSelectedAllChanged(value);
        }
    }
    private void SelectedAllChanged(bool? input)
    {
        //Stuff
    }
