    private void DetermineWhetherDBNullIsValid()
    {
        bool flag = false;
        object item = this.GetItem(this.Length - 1);
        if ((item != null) && AssemblyHelper.IsLoaded(UncommonAssembly.System_Data))
        {
            flag = this.DetermineWhetherDBNullIsValid(item);
        }
        this._isDBNullValidForUpdate = new bool?(flag);
    }
