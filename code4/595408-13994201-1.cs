    myDataReader.Close();
    connection.Close();
    SqlConnection connection2 = new SqlConnection(connStr);
    SqlCommand myCommand2 = new SqlCommand(myQuery2, connection2);
    SqlDataReader myDataReader2;
    connection2.Open();
    myDataReader2 = myCommand2.ExecuteReader();
    if (myDataReader2.HasRows) {
        string last_id = string.Empty;
        while (myDataReader2.Read()) {
            string court_id = myDataReader2["court_id"].ToString();
            string court_contact_desc = myDataReader2["court_contact_type_desc"].ToString();
            string court_contact_name = myDataReader2["court_contacts_name"].ToString();
            string court_contact_no = myDataReader2["court_contacts_no"].ToString();
            if (string.IsNullOrWhiteSpace(court_contact_no)) {
                court_contact_no = generic_contact_no;
            }
            if (last_id != court_id) {
                Response.Write(court_contact_name + " - " + court_contact_desc + ": " + court_contact_no + "<br>");
            } else {
                Response.Write(court_contact_name + " - " + court_contact_desc + ": " + court_contact_no + "<br>");
            }
            last_id = court_id;
        }
    }
