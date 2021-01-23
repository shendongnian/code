    public void ReadBarcode(ComboBox cmbx)
    {
        FieldInfo info = cmbx.GetType().GetField("SelectedIndexChanged", BindingFlags.Instance | BindingFlags.NonPublic);
        if (info != null)
        {
           object obj = info.GetValue(cmbx);
           if (obj is EventHandler)
           {
              EventHandler handler = (EventHandler)obj;
              cmbx.SelectedIndexChanged -= handler;
              //              
              // Perform your bar code reading here.
              // 
              cmbx.SelectedIndexChanged += handler;
           }
        }
    }
