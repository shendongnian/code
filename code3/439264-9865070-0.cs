    string sqlQuery = "Select * from BLOG order by BlogID DESC";
    using (SqlConnection con = new SqlConnection(cnString))
    {
        con.Open();
        using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
        {
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                System.Web.UI.HtmlControls.HtmlGenericControl dynDiv =
                new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                dynDiv.ID = "BlogPost";
                dynDiv.InnerHtml = "<div id=\"BlogTitle\">" +
                    dr["BlogTitle"] + "</div><br /><div id=\"BlogDate\">"
                    + dr["BlogDate"].ToString() + "</div><br /><br /><div id=\"BlogText\">"
                    + dr["BlogText"] + "</div>";
                Label1.Controls.Add(dynDiv);
            }
        }
    }
