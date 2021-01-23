    private void previousList_Click(object sender, EventArgs e)
    {
        pid = 14;
    
        XDocument xDoc = XDocument.Load(@"C:\Users\HDAdmin\Documents\Fatty\SliceEngine\SliceEngine\bin\Debug\simpan.xml");
    
        var name = xDoc.Descendants("myself")
                        .First(m => (int)m.Element("PatientID") == pid)
                        .Value;
    
        textETA.Text = name;
    }
