    public override void OnDataSet()
    {
        Logger.Log("this.Data = " + (this.Data == null ? "null" : this.Data.GetType().Name));
        option = this.Data as OptionSelectorData;
        if (option != null)
        {
            OptionTitle = option.Title;
            itemsSource = option.Options;
        }
        else
        {
            Logger.Log("NULL Option Data");
        }
    }
