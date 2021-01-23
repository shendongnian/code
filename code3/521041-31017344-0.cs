    //populate the Programs dropdownlist according to the student's study year / preference
    DropDownList ddlPrograms = (DropDownList)DetailsView1.FindControl("ddlPrograms");
    if (ddlPrograms != null)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ATCNTV1ConnectionString"].ConnectionString))
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT ProgramID, ProgramName FROM tblPrograms WHERE ProgramCatID > 0 AND ProgramStatusID = (CASE WHEN @StudyYearID = 'VPR' THEN 10 ELSE 7 END) AND ProgramID NOT IN (23,112,113) ORDER BY ProgramName";
                cmd.Parameters.Add("@StudyYearID", SqlDbType.Char).Value = "11";
                DataTable wsPrograms = new DataTable();
                wsPrograms.Load(cmd.ExecuteReader());
                //populate the Programs ddl list
                ddlPrograms.DataSource = wsPrograms;
                ddlPrograms.DataTextField = "ProgramName";
                ddlPrograms.DataValueField = "ProgramID";
                ddlPrograms.DataBind();
                ddlPrograms.Items.Insert(0, new ListItem("<Select Program>", "0"));
            }
            catch (Exception ex)
            {
                // Handle the error
            }
        }
    }
