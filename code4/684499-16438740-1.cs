        protected void Page_Load(object sender, EventArgs e)
        {
            var ctx = HttpContext.Current;
            System.Threading.Tasks.Parallel.Invoke(() => Display(ctx), () => Display2(ctx));
        }
        public void Display(HttpContext context)
        {
            if (context != null)
            {
                Response.Write("Method 1" + context.User.Identity.Name);
            }
            else
            {
                Response.Write("Method 1 Unknown");
            }
        }
        public void Display2(HttpContext context)
        {
            if (context != null)
            {
                Response.Write("Method 2" + context.User.Identity.Name);
            }
            else
            {
                Response.Write("Method 2 Unknown");
            }
        }
