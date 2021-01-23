    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string id, type, UniqueColID;
            string FilePath = Server.MapPath("~").ToString();
            type = Request.QueryString["type"];
            if (type.Equals("template"))
            {
                MergeDocument template = new MergeDocument(FilePath + @"\Template\MVCTemplate.pdf");
                template.DrawToWeb();
            }
            else
            {
                id = Request.QueryString["id"];
                UniqueColID = DBFunctions.DBFunctions.testExist(id);
                MergeDocument doc;
                if (DBFunctions.DBFunctions.FlagDriverPrintOnly == false)
                {
                   doc = PDF.LongFormManipulation.generatePDF(id, type, FilePath, UniqueColID);
                }
                else if (DBFunctions.DBFunctions.FlagDriverPrintOnly == true)
                {
                    doc = PDF.LongFormManipulation.generatePDFDriverOnly(id, type, FilePath, UniqueColID);
                }
                DBFunctions.DBFunctions.FlagDriverPrintOnly = false;
                    if (doc == null)
                    doc = new MergeDocument(FilePath + @"\Template\MVCTemplate.pdf");
                doc.DrawToWeb();
            }
        }
        catch(Exception err)
        {
            MessageBox("Creating PDF file was not successful. " + err.ToString());
        }
