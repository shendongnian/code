    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)Master.FindControl("titleBar")).Text = "More Information";
        if (!IsPostback)
        {
            float ID = float.Parse(Request.QueryString["ID"]);
            DataTable tbl = appsql.appSpecific(ID);
            App_Name_E.Text = tbl.Rows[0]["App_Name"].ToString();
            Description_E.Text = tbl.Rows[0]["Description"].ToString();
            App_Owner_E.Text = tbl.Rows[0]["App_Owner"].ToString();
            CS_E.SelectedIndex = (Convert.ToInt16(tbl.Rows[0]["Coexistence_Status"].ToString()));
            CP_E.SelectedIndex = (Convert.ToInt16(tbl.Rows[0]["Coexistence_Progress"].ToString()));
            TSO_E.Text = tbl.Rows[0]["TSO"].ToString();
            Migration_Phase_E.SelectedIndex = (Convert.ToInt16(tbl.Rows[0]["Migration_Phase"].ToString())) + 1;
            Responsible_Manager_E.Text = tbl.Rows[0]["Responsible_Manager"].ToString();
            Next_Steps_E.Text = tbl.Rows[0]["Next_steps"].ToString();
            Sign_Off_E.Text = tbl.Rows[0]["Sign_Off"].ToString();
        }
    }
This will stop your controls from being reinitialized each time on Page_Load, which will allow your Update_Click method to pick up the new values and update the database correctly.
