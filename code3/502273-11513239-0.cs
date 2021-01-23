        string datestyle = @"<style>.date { mso-number-format:'Short Date'; }</style>";
        foreach (GridViewRow oItem in gvEdit.Rows)
            oItem.Cells[4].Attributes.Add("class", "date");
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment; filename=SupplierList.xls");
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter WriteItem = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlText = new HtmlTextWriter(WriteItem);
        Response.Write(datestyle);
        gvEdit.RenderControl(htmlText);
        Response.Write(WriteItem.ToString());
        Response.End();
