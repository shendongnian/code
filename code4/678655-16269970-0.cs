    string Item1;
    string Item2;
    private string GetFileName()
    {
        var returnValue = (string)null;
        OpenFileDialog OFD = new OpenFileDialog();
        if (OFD.ShowDialog() == DialogResult.OK)
        {
           // Removed TRY-CATCH block for simplicity
           returnValue = OFD.FileName;
        }
        return returnValue;
    }
    private void button1Click(object sender, EventArgs e)
    {
        Item1 = GetFileName();
        if (!string.IsNullOrWhiteSpace(Item1)){
             _model.LoadItemType1(Item1);
        }
    }
    private void button2Click(object sender, EventArgs e)
    {
         Item2 = GetFileName();
        if (!string.IsNullOrWhiteSpace(Item2)){
             _model.LoadTotallyDifferentItem(Item2);
        }
    }
