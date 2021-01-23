        protected void Page_Load(object sender, EventArgs e)
        {
            MyPageClass p = this.Page as MyPageClass ;
            p.UpdateAsyncMode(true);
        }
