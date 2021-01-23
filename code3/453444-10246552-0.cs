    protected void Page_Load(object sender, EventArgs e)
    {
        string xmlFile = Server.MapPath("~/App_Data/file.xml");
        try
        {
            XmlDataSource1.DataFile = xmlFile;
            XmlDataSource1.GetXmlDocument();
        }
        catch (Exception ex)
        {
            lblErrorMessage.Visible = true;
            gridView1.Visible = false;
            formView1.Visible = false;
        }
    }
