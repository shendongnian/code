    con = new SqlConnection();
    con.ConnectionString = ConClass.conString();
    string newstud = "SELECT MAX(StudentRegNo) FROM NewStudent";
    try{
      RegNo = (int.Parse(search(newstud)) + 1);
    }
    catch{
      RegNo = 1;
    }
    lblStuReg.Text = "AP/HQ/" + RegNo.ToString();
