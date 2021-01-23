    string setTestNameSQL = "UPDATE TestCases SET TestName = @TestName WHERE TestCaseID = @TestCaseID";
    SqlConnection conn = new SqlConnection(GetConnectionString());
    SqlCommand cmdUpdateTestName = new SqlCommand(setTestNameSQL, conn);
    TextBox tb = (TextBox)e.Item.FindControl("TxtUpdateTestName");
    SqlParameter u1 = new SqlParameter("@TestName", tb.Text);
    SqlParameter u2 = new SqlParameter("@TestCaseID", e.CommandArgument);
    cmdUpdateTestName.Parameters.Add(u1);
    cmdUpdateTestName.Parameters.Add(u2);
