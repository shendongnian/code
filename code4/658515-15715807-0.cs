    [WebMethod]
    public AjaxControlToolkit.Slide[] GetSlides(DataTable dt)
    {
        AjaxControlToolkit.Slide[] slides = new AjaxControlToolkit.Slide[dt.Rows.Count];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DataRow dr = dt.Rows[i];
            slides[i] = new AjaxControlToolkit.Slide(dr["imgurl"].ToString().Replace("\\", "/"), dr["header"].ToString(), dr["descr"].ToString());
        }
        return slides;
    }
