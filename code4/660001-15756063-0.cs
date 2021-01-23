    [HttpPost]
        public ActionResult Admin(string txt_file_dest, string report_dest, string sql_Connection)
        {
            AdminModel Values = new AdminModel();
    
            if (sql_Connection != null)
            {
                Values.SAVEsqlConnection(sql_Connection);       
            }
    
             return RedirectToAction("actionname");//call same page action again
        }
