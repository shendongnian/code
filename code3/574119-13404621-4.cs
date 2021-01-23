    using (var connection = new SqlConnection(connectionString))
    {
        connection.Open();
        return Json(new {
           myTable = connection.Query<MyItem>("SELECT * FROM MyDBtable").ToList()
        }, JsonRequestBehavior.AllowGet);
    }
