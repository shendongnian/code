    [System.Web.Services.WebMethodAttribute()]
    [System.Web.Script.Services.ScriptMethodAttribute()]
    public static AjaxControlToolkit.Slide[] GetSlides()
    {
        CAProcessAccess ImageProc = new CAProcessAccess("master"); //CAProcessAccess class that obtains data from database
        DataSet ds = ImageProc.GetRecords("", "SP_Gallery_Image", "GETID", comCode, proCode, "", "");
        DataTable dt = ds.Tables[0];
        AjaxControlToolkit.Slide[] slides = new AjaxControlToolkit.Slide[dt.Rows.Count];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            int imgID = Convert.ToInt32(dt.Rows[i]["ID"]);
            slides[i] = new AjaxControlToolkit.Slide("ShowImage.ashx?ID=" + imgID, "test", "test"); //sending the imgID to the handler to show which image will be viewed in slide
        }
        return slides;
    }
