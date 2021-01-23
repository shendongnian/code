    Array values = Enum.GetValues(typeof(BeltPrinterType));//If this doesn't help in compact framework try below code
    Array values = GetBeltPrinterTypes();//this should work, rest all same
    foreach (var item in values)
    {
        listbox.Items.Add(item);
    }
    private static BeltPrinterType[] GetBeltPrinterTypes()
    {
        FieldInfo[] fi = typeof(BeltPrinterType).GetFields(BindingFlags.Static | BindingFlags.Public);
        BeltPrinterType[] values = new BeltPrinterType[fi.Length];
        for (int i = 0; i < fi.Length; i++)
        {
            values[i] = (BeltPrinterType)fi[i].GetValue(null);
        }
        return values;
        }
    private void listBoxBeltPrinters_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if(!(listBoxBeltPrinters.SelectedItem is BeltPrinterType))
        {
            return;
        }
        PrintUtils.printerChoice = (BeltPrinterType)listBoxBeltPrinters.SelectedItem;
    }
