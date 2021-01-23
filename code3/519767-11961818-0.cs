    using(reader)
    {
       System.Data.DataTable dt = new System.Data.DataTable();
       dt.Load(reader);
       
       foreach(DataRow row in dt.Rows)
       {
            addtolog("mysql",row["nations_name"].ToString());
    
            int nation_ID = int.Parse(row["nations_ID"].ToString());
            string nation_name = row["nations_name"].ToString();
            string user_ID = row["nations_user"].ToString();
    
    
            addnation(nation_ID, nation_name, user_ID);
       }
    }
