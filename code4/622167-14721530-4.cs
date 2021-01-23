    public bool trackSelectedElement
    {
        get {
            bool result;
            if(bool.TryParse(this.currentConfig.AppSettings.Settings["trackSelectedElement"].Value, out result)) {
                return result;
            }
            else {
                return true;
            }
        }
        set {
            this.currentConfig.AppSettings.Settings["trackSelectedElement"].Value = value.ToString();
        }
    }
