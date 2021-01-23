        private static readonly object LockObj = new object();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Counted"] == null)
            {
                DataSet dataSet = new DataSet();
                lock (LockObj)
                {
                    dataSet.ReadXml(Server.MapPath("~/counter.xml"));
                    dataSet.Tables[0].Rows[0]["hits"] = (1 + int.Parse(dataSet.Tables[0].Rows[0]["hits"].ToString())).ToString();
                    dataSet.WriteXml(Server.MapPath("~/counter.xml"));
                }
                Session["Counted"] = "true";               
            }
        }
