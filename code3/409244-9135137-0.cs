    Binding mtbGebdatBinding = mtbGebdat.DataBindings.Add("Text", _bsPerson, (string)mtbGebdat.Tag, true);
    mtbGebdatBinding.Format += new ConvertEventHandler(mtbGebdatBinding_Format);
    void mtbGebdatBinding_Format(object sender, ConvertEventArgs e)
    {
        if (DBNull.Value != e.Value)
        {
           string date = String.Format("{0:dd/MM/yyyy}", (DateTime)e.Value);
            if (date.Substring(6, 4) == "1900")
            {
                e.Value = date.Substring(0, 6);
            }
        }
    }
