    SqlCommand cmd = con.CreateCommand();
    cmd.CommandText = "SELECT DISTINCT State FROM MyDBtable";
    con.Open();
    List<string> StateList = new List<string>();
    SqlDataReader reader = cmd.ExecuteReader();
    while (reader.Read())
    {
        StateList.Add(reader[0].ToString());
    }
    return Json(new
    {
        myTable = StateList.Select(i => new { State = i });
    }, JsonRequestBehavior.AllowGet);
