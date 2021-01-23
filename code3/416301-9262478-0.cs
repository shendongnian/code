    const string defaultExtensionsList = "doc;docx;xlsx;xls;pdf;txt";
    //...
    var columnID = new LookUpColumnInfo("Column", "IDs") { Visible = false };
    var columnToDisplay = new LookUpColumnInfo("Display", "Extensions");
    lookUpEdit.Properties.Columns.AddRange(new LookUpColumnInfo[] { columnID, columnToDisplay });
    lookUpEdit.Properties.ValueMember = "Column";
    lookUpEdit.Properties.DisplayMember = "Display";
    lookUpEdit.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
    lookUpEdit.Properties.GetNotInListValue += OnGetNotInListValue;
    var bindingList = defaultExtensionsList.Split(';').ToList();
    lookUpEdit.Properties.DataSource = bindingList;
    //...
    void OnGetNotInListValue(object sender, GetNotInListValueEventArgs e) {
        if(e.FieldName == "Display")
            e.Value = string.Format("Document type (*.{0})",
                ((IList<string>)lookUpEdit.Properties.DataSource)[e.RecordIndex]);
    }
