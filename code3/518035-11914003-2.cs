    private void LoadDatagrid()
    {
        try
        {
            using (XmlReader xmlFile = XmlReader.Create(filePath, 
                                                        new XmlReaderSettings()))
            {
                DataSet ds = new DataSet();
                ds.ReadXml(xmlFile);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }
