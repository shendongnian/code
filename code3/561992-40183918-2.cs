    try
    {
        bs.EndEdit(); // needs to be called before getting changes.
        DataSet dsChanges = belkData.GetChanges();
        if (dsChanges != null)
        {
            int nRows = sdaMem.Update(dsChanges);
            MessageBox.Show("Row(s) Updated: " + nRows.ToString());
            belkData.AcceptChanges();
        }
        else { MessageBox.Show("Nothing to save.", "No changes"); }
    }
    catch (Exception ex)
    {
        MessageBox.Show("Error: " + ex.Message);
    }
