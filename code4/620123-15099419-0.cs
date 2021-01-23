    public override object EditValue(ITypeDescriptorContext context,
    IServiceProvider serviceprovider, object value)
    {
    if (serviceprovider != null)
    {
    mapiEditorService = serviceprovider
    .GetService(typeof(IWindowsFormsEditorService)) as
    IWindowsFormsEditorService;
    }
    if (mapiEditorService != null)
    {
    StringCollectionForm form = new StringCollectionForm();
    // Retrieve previous values entered in list.
    if (value != null)
    {
    List stringList = (List)value;
    form.txtListValues.Text = String.Empty;
    foreach (string stringValue in stringList)
    {
    form.txtListValues.Text += stringValue + "\r\n";
    }
    }
    // Show Dialog.
    form.ShowDialog();
    if (form.DialogResult == DialogResult.OK)
    {
    List stringList = new List();
    string[] listSeparator = new string[1];
    listSeparator[0] = "\r\n";
    string[] listValues = form.txtListValues.Text
    .Split(listSeparator, StringSplitOptions.RemoveEmptyEntries);
    // Add list values in list.
    foreach (string stringValue in listValues)
    {
    stringList.Add(stringValue);
    }
    value = stringList;
    }
    return value;
    }
    return null;
    }
