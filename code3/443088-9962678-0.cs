        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Collection"] == null)
            {
                Session["Collection"] = new List<int>();
            }//if
        }
        protected void button_clickSell(object sender, EventArgs e)
        {
            List<int> collection = (List<int>)Session["Collection"];
            collection.Add(7);
            collection.Add(9);
        }
        protected void button_clickView(object sender, EventArgs e)
        {
            List<int> collection = (List<int>)Session["Collection"];
            collection.Add(10);
        }
