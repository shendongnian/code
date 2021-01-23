    private void PrinterPickerForm_Load(object sender, System.EventArgs e)
    {
    	Type type = typeof(PrintUtils.BeltPrinterType);
    	foreach (FieldInfo field in type.GetFields(BindingFlags.Static | BindingFlags.Public))
    	{
    		string display = field.GetValue(null).ToString();
    		listBoxBeltPrinters.Items.Add(display);
    	}
    	string currentPrinter = AppSettings.ReadSettingsVal("beltprinter");
    	lblCurrentPrinter.Text = currentPrinter;
    	int currentPrinterIndex = listBoxBeltPrinters.Items.IndexOf(currentPrinter);
    	listBoxBeltPrinters.SelectedIndex = currentPrinterIndex;
    }
    
    private void btnSaveSelectedVal_Click(object sender, System.EventArgs e)
    {
    	string sel = listBoxBeltPrinters.SelectedItem.ToString();
    	if (sel != lblCurrentPrinter.Text)
    	{
    		AppSettings.WriteSettingsVal("beltPrinter", sel);
    	}
    }
