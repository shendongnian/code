    string command = @"DELETE FROM Student WHERE StudCode = @StudCode";
    SqlCommand com2 = new SqlCommand(command, con);
    SqlParameter q1 = new SqlParameter("@StudCode", Session["StudCode"]);
    com2.Parameters.Add(q1); // Also com2 now
    com2.ExecuteNonQuery(); // Added to run the query
    Response.Redirect("Default.aspx");
