    foreach (tblDocuments vv in all)
    {
        string doctitle = vv.DocumentNo;
        for (int i = vv.DocumentNo.Length; i < maxs + 2; i++)
        {
            doctitle += "&nbsp;";
        }
        doctitle += "&nbsp;|&nbsp;";
        doctitle +=  vv.DocID;
        // Use HtmlDecode to correctly show the spaces
        doctitle = HttpUtility.HtmlDecode(doctitle );
        ddlStack.Items.Add(new ListItem(doctitle, vv.vendorID.ToString()));
    }
