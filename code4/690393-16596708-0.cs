        Response.AddHeader("content-disposition", "attachment;filename=Export.doc");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.word";
        StringWriter stringWrite = new StringWriter();
        HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        HtmlForm frm = new HtmlForm();
        /*--------------*/
        GridView1.Columns(0).Visible = false; //HIDE EDIT
        GridView1.Columns(1).Visible = false; //HIDE DELETE
        GridView1.AllowSorting = false; //Disable Sorting
        GridView1.DataBind();
        /*--------------*/
        GridView1.Parent.Controls.Add(frm);
        frm.Attributes["runat"] = "server";
        frm.Controls.Add(GridView1);
        frm.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
