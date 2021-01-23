    private void uxMappingDataGridView_Leave(object sender, EventArgs e)
    {
        SaveGridValuesToXml();
    }
    
    private void SaveGridValuesToXml()
    {   
        uxMappingDataGridView.EndEdit(DataGridViewDataErrorContexts.Commit);
        xmlData.DataSet.WriteXml(@"C:\testFile.xml");
    }
