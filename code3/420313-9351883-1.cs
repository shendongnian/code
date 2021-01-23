    protected void Page_Load(object sender, EventArgs e)
    {
        //read how many DropDownList controls are needed
        int ddlCount = txtDropDownList.Text;
        
        for (int i = 0; i < ddlCount; ++i)
        {
            if (i > 0)
            {
                //add a page break between previous DropDownList and the current one
                this.Controls.Add(LiteralControl("<br />"));
            }
            
            //add a DropDownList with ID productDdl and an appropriate number
            this.Controls.pageContent.Add(new DropDownList() { ID = String.Format("productDdl{0}", i) });
        }
    }
