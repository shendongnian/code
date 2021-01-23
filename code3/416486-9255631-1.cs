    //TO KEEP TRACK OF EMPLOYEE IDS FOR WHICH WE HAVE ALREADY EXECUTED 
    //DELETE STATEMENT
    IList<string> _deleted=new List<string>();
    foreach (Control ctrl in PlaceHolder1.Controls)
    {
        ...........
        .........
    
        if (c is CheckBox)
        {
            CheckBox checkbox = (CheckBox)c;
            if (checkbox.Checked)
            {
                string fieldvalue = checkbox.ID;
                string employeeID = fieldvalue.Split(new string[] { "," }, 
                                       StringSplitOptions.RemoveEmptyEntries)[0];
                string courseID = fieldvalue.Split(new string[] { "," }, 
                                       StringSplitOptions.RemoveEmptyEntries)[1];
                if(!_deleted.Contains(employeeID))
                {
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                       conn.Open();
                       using (SqlCommand cmd = new SqlCommand(deleteCommand, conn))
                       {
                          cmd.Pararmeters.AddWithValue("@employeeId", employeeID);
                          cmd.ExecuteNonQuery();
                          //DON'T EXECUTE DELETE FOR ALL CHECKED ROWS
                          _deleted.Add(employeeID);
                       }
                    }
                }
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(insertCommand, conn))
                    {
                       //Now the insert
                       cmd.CommandText = insertCommand;
                       //DON'T NEED TO CLEAR AS YOU HAVE CREATED NEW COMMAND IN 
                       //USING STATEMENT
                       //cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@employeeId", employeeID);
                        Cmd.Parameters.AddWithValue("@CourseID", courseID);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            .....................
            .....................
        }
        .....................
        .....................
    }
