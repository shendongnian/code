       protected void Page_Load(object sender, EventArgs e)
        {
            if (PageBody != null)
            {
                 PageBody.Attributes.Add("class", "myClass");
            }
        }
