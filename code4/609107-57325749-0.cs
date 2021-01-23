        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (MayEntities context = new MayEntities())
                {
                    string str = context.Database.SqlQuery<string>("select dbo.HeyYou()").Single().ToString();
                    Response.Write(str); //output:'Hey this works'
                }
            }
        }
