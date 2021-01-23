    public void counter(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString);
        string[] commands = {
                                "SELECT COUNT(*) FROM SafetySuggestionsLog"
                            };
        int[] SSCount = new int[commands.Length];
        try
        {
            for (int i = 0; i < commands.Length; i++)
            {
                SqlCommand cmd = new SqlCommand(commands[i], conn);
                conn.Open();
                SSCount[i] = (int)cmd.ExecuteScalar();
                conn.Close();
            }
            All_SafetySuggestions_Tab.HeaderText += " (" + SSCount[0] + ")";
        }
        catch (Exception ex) { string ee = ex.Message; }
    }
    public void creat_word_table(object sender, EventArgs e)
    {
        ListView lv = new ListView();
        // THIS IS WHERE I'VE MADE A CHANGE.  INSTEAD OF == USE STARTSWITH TO ACCOUNT FOR
        // YOUR COUNT METHOD APPENDING HEADER NAMES WITH A COUNT.
        if (TabContainer1.ActiveTab.HeaderText.StartsWith("Last Three Months")) { lv = Last_Three_Months_ListView; }
        else if (TabContainer1.ActiveTab.HeaderText.StartsWith("All")) { lv = ListView1; }
        //lv.Items.Clear();
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Charset = "";
        HttpContext.Current.Response.ContentType = "application/msword";
        string tab_name = TabContainer1.ActiveTab.HeaderText;
        string strFileName = tab_name + ".doc";
        HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename=" + strFileName);
        StringBuilder strHTMLContent = new StringBuilder();
        strHTMLContent.Append(" <h1 title='Heading' align='Center' style='font-family:verdana;font-size:80%;color:black'><u>" + tab_name + "</u> </h1>".ToString());
        strHTMLContent.Append("<br>".ToString());
        strHTMLContent.Append("<table cellspacing='0' width='100%' style='border:2px solid #003366; font-size:17px; font-weight:bold;'>".ToString());
        strHTMLContent.Append("<tr>".ToString());
        strHTMLContent.Append("<th style='border-bottom:2px solid #003366; '>Title</th>".ToString());
        strHTMLContent.Append("<th style='border-bottom:2px solid #003366; '>Description</th>".ToString());
        strHTMLContent.Append("<th style='border-bottom:2px solid #003366; '>Type</th>".ToString());
        strHTMLContent.Append("<th style='border-bottom:2px solid #003366; '>Username</th>".ToString());
        strHTMLContent.Append("<th style='border-bottom:2px solid #003366; '>Name</th>".ToString());
        strHTMLContent.Append("<th style='border-bottom:2px solid #003366; '>Division</th>".ToString());
        strHTMLContent.Append("<th style='border-bottom:2px solid #003366; '>Submitted Date</th>".ToString());
        strHTMLContent.Append("</tr>".ToString());
        for (int i = 0; i < lv.Items.Count; i++)
        {
            CheckBox chk = lv.Items[i].FindControl("CheckBox2") as CheckBox;
            if (chk.Checked)
            {
                strHTMLContent.Append("<tr>".ToString());
                strHTMLContent.Append("<td style='border:1px solid #003366;width: 100px'>" + ((Label)lv.Items[i].FindControl("lblTitle")).Text + "</td>".ToString());
                strHTMLContent.Append("<td style='border:1px solid #003366;width: 100px'>" + ((Label)lv.Items[i].FindControl("lblDescription")).Text + "</td>".ToString());
                strHTMLContent.Append("<td style='border:1px solid #003366;width: 100px'>" + ((Label)lv.Items[i].FindControl("lblType")).Text + "</td>".ToString());
                strHTMLContent.Append("<td style='border:1px solid #003366;width: 100px'>" + ((Label)lv.Items[i].FindControl("lblUsername")).Text + "</td>".ToString());
                strHTMLContent.Append("<td style='border:1px solid #003366;width: 100px'>" + ((Label)lv.Items[i].FindControl("lblName")).Text + "</td>".ToString());
                strHTMLContent.Append("<td style='border:1px solid #003366;width: 100px'>" + ((Label)lv.Items[i].FindControl("lblDivision")).Text + "</td>".ToString());
                strHTMLContent.Append("<td style='border:1px solid #003366;width: 100px'>" + ((Label)lv.Items[i].FindControl("lblSubmittedDate")).Text + "</td>".ToString());
                strHTMLContent.Append("</tr>".ToString());
            }
        }
        strHTMLContent.Append("</table>".ToString());
        strHTMLContent.Append("<br><br>".ToString());
        HttpContext.Current.Response.Write(strHTMLContent);
        HttpContext.Current.Response.End();
        HttpContext.Current.Response.Flush();
    }
