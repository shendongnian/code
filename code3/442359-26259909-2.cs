    void SaveDataGridViewToCSV(string filename)
    {
        // Save the current state of the clipboard so we can restore it after we are done
        IDataObject objectSave = Clipboard.GetDataObject();
        
        // Choose whether to write header. Use EnableWithoutHeaderText instead to omit header.
        dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
        // Select all the cells
        dataGridView1.SelectAll();
        // Copy (set clipboard)
        Clipboard.SetDataObject(dataGridView1.GetClipboardContent());
        // Paste (get the clipboard and serialize it to a file)
        File.WriteAllText(filename,Clipboard.GetText(TextDataFormat.CommaSeparatedValue));
        
        // Restore the current state of the clipboard so the effect is seamless
        if(objectSave != null) // If we try to set the Clipboard to an object that is null, it will throw...
        {
        	Clipboard.SetDataObject(objectSave);
        }
    }
