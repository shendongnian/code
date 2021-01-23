    public bool? AreAllSelected
    {
        get
        {
            return this.Items.All(candidate => candidate.IsSelected)
            ? true
            : this.Items.All(candidate => !candidate.IsSelected)
                ? (bool?)false
                : null;
        }
        set
        {
            if (value != null)
            {
                foreach (var item in this.Items)
                {
                    item.IsSelected = value.Value;
                }
            }
            this.RaisePropertyChanged();
        }
    }
