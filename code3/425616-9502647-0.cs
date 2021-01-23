        protected void Submit_Click(object sender, EventArgs e)
        {
            if (SomeCondition(x,y))
            {
                ViewState["foo"] = "apple";
                ViewState["bar"] = "orange";
            }
        }
    
        protected void ShowFooBar_Click(object sender, EventArgs e)
        {
            if(ViewState["foo"] != null && ViewState["bar"] != null)
            {
                Response.Write("foo=" + ViewState["foo"] + "& bar=" + ViewState["bar"]);
            }
        }
