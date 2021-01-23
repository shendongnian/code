        string SQL = "Select BLOG.BlogTitle, BLOG.BlogDate, BLOG.BlogText from BLOG order by BlogID DESC";
        // Positions of the columns you are reading
        const int TITLE_ORDINAL = 0;
        const int DATE_ORDINAL = 1;
        const int TEXT_ORDINAL = 2;
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var con = new SqlConnection(cnString))
            {
                con.Open();
                try
                {
                    using (var oCommand = new SqlCommand(SQL, con))
                    {
                        using (var oReader = oCommand.ExecuteReader())
                        {
                            while (oReader.Read())
                            {
                                var dynDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                                dynDiv.ID = "BlogPost";
                                dynDiv.InnerHtml = "<div id=\"BlogTitle\">" +
                                    oReader.GetString(TITLE_ORDINAL) + "</div><br /><div id=\"BlogDate\">"
                                    + oReader.GetString(DATE_ORDINAL) + "</div><br /><br /><div id=\"BlogText\">"
                                    + oReader.GetString(TEXT_ORDINAL) + "</div>";
                                Label1.Controls.Add(dynDiv);
                            }
                        }
                    }
                } finally {
                    con.Close();
                }
            }
        }
