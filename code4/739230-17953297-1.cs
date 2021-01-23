    var values = Enum.GetValues(typeof(BeltPrinterType));
    foreach (var item in values)
    {
        listbox.Items.Add(item);
    }
    private void listBoxBeltPrinters_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if(!(listBoxBeltPrinters.SelectedItem is BeltPrinterType))
        {
            return;
        }
        PrintUtils.printerChoice = (BeltPrinterType)listBoxBeltPrinters.SelectedItem;
    }
