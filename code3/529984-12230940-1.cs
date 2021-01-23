    private void frmXmlDeserialize_Load(object sender, EventArgs e)
    {
        try
        {
            XmlSerializer xs = new XmlSerializer(typeof(Root));
            StreamReader sr = new StreamReader("import.xml");
            Root r = (Root)xs.Deserialize(sr);
            sr.Close();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }           
    }
