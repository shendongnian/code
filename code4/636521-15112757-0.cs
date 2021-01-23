    public Action<Exception> OnExceptionInUserControl;
    public bool IsSavedImage(IList<AppConfig> AppConfigs, string ImageNameFilter)
    {
        bool IsCopied = false;
        try
        {
            string imgPath = AppConfigs[0].ConfigValue.ToString();
            File.Copy(selectedFile, imgPath + "\\" + ImageNameFilter + slectedFileName + ".jpeg");
            IsCopied = true;
        }
        catch (IOException copyError)
        {
            OnExceptionInUserControl(copyError);
            return false;
        }
        return IsCopied;
    }
