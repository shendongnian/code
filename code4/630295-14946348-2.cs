    protected void Page_Load(object sender, EventArgs e)
    {
        Literal2.Text = CreateChart_2();
    }
    public string CreateChart_2()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
        // Initialize the string which would contain the chart data in XML format
        StringBuilder xmlStr = new StringBuilder();
        // Provide the relevant customization attributes to the chart
        xmlStr.Append("<chart decimalPrecision='0' showShadow='1' showborder='1' caption='Number of Lots Assigned (YTD)' subcaption='" + result1 + "'   name='MyXScaleAnim' type='ANIMATION' duration='1' start='0' param='_xscale' showNames='1' labelDisplay='Rotate'  useEllipsesWhenOverflow='1' formatNumberScale='0'>");
        {
            // Establish the connection with the database
            string sqlStatement = "SELECT count (ID)as TotalCount, cat_name FROM MyTable group by cat_name";
            SqlCommand cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            // Begin iterating through the result set
            //SqlDataReader rst = query.ExecuteReader();
            while (reader.Read())
            {
                // Construct the chart data in XML format
                xmlStr.AppendFormat("<set label='{0}' value='{1}' link='{2}'/>", reader["cat_name"].ToString(), reader["TotalCount"].ToString(), Server.UrlEncode("DrillDown1.aspx?AppName=" + reader["cat_name"].ToString()));
            }
            // End the XML string
            xmlStr.Append("</chart>");
            // Close the result set Reader object and the Connection object
            reader.Close();
            con.Close();
            // Set the rendering mode to JavaScript, from the default Flash.
            FusionCharts.SetRenderer("javascript");
            // Call the RenderChart method, pass the correct parameters, and write the return value to the Literal tag
            Literal2.Text = FusionCharts.RenderChart(
                "FusionChartsXT/Column3D.swf", // Path to chart's SWF
                "", // Page which returns chart data. Leave blank when using Data String.
                xmlStr.ToString(), // String containing the chart data. Leave blank when using Data URL.
                "annual_revenue",   // Unique chart ID
                "640", "340",       // Width & Height of chart
                false,              // Disable Debug Mode
                true);
        }
        return xmlStr.ToString();
    }
