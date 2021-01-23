    void SaveDataGridViewToCSV(string filename)
    {        
        // Choose whether to write header. Use EnableWithoutHeaderText instead to omit header.
        dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
        // Select all the cells
        dataGridView1.SelectAll();
        // Copy selected cells to DataObject
        DataObject dataObject = dataGridView1.GetClipboardContent();
        // Get the text of the DataObject, and serialize it to a file
        File.WriteAllText(filename, dataObject.GetText(TextDataFormat.CommaSeparatedValue));
    }
