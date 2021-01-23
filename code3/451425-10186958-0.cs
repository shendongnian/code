    string attachment = "attachment; filename=Contacts.xls";
    Response.ClearContent();
    Response.AddHeader("content-disposition", attachment);
    Response.ContentType = "application/ms-excel";
    StringWriter sw = new StringWriter();
    HtmlTextWriter htw = new HtmlTextWriter(sw);
    GridView1.RenderControl(htw);
    Response.Write(sw.ToString());
    Response.End(); 
