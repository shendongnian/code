    //Page Source
                Session["tbl"] = dt.Rows; // table id = td
                Response.Redirect("WebForm4.aspx");
    
                // page Destination
                HtmlTableRowCollection tr = (HtmlTableRowCollection)Session["tbl"];
    
                foreach (HtmlTableRow t in tr)
                {
                    dt.Rows.Add(t); // table id = td
                }  
