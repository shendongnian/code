    foreach (DataRow drOutput in dtOutput.Rows)
    {
        HtmlGenericControl li = new HtmlGenericControl("li");
        tabs.Controls.Add(li); // tabs is id of ul tag which is runat=server
        foreach (DataColumn dcOutput in dtOutput.Columns)
        {
            HtmlGenericControl anchor = new HtmlGenericControl("a");
            anchor.Attributes.Add("href", Convert.ToString(drOutput["ModuleFileName"]));
            anchor.InnerText = Convert.ToString(drOutput["ModuleName"]);
            li.Controls.Add(anchor);
        }
    }
