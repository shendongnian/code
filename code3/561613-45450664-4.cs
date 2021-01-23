    public void Execute(object parameter)
    {
        var allSelected = this.AreAllSelected;
        switch (allSelected)
        {
            case true:
                this.AreAllSelected = false;
                break;
            case false:
            case null:
                this.AreAllSelected = true;
                break;
        }
    }
