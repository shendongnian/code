    [WebMethod]
        public List<product> getdata()
        {
            List<product> productt = new List<product> {};
            string query = "SELECT [product] ,[img1] ,[descr] FROM [ELQ].[dbo].[products]";
            SqlCommand cmd = new SqlCommand(query);
            DataSet ds = GetData(cmd);
            DataTable dt = ds.Tables[0];
            foreach(DataRow item in ds.Tables[0].Rows)
            {
                product pro = new product();
                pro.name = item["product"].ToString();
                pro.img1 = item["img1"].ToString();
                pro.descr = item["descr"].ToString();
                productt.Add(pro);
            }
    
            return productt; 
        }
 
