        protected void Page_Load(object sender, EventArgs e)
            {
                string vs = (string)ViewState["buttonClicked"];
                string isEditing = (string)ViewState["isEditing"];
                if (**!IsPostBack**)                     
                    **^^^**
     /*just bind gridview when page is not 
            postback this will not bind oyur gridview on your every request*/
                    if (vs == "False")
                    {
                        RadioButtonListChanged();
                        GridView1.DataBind();
                    }
                    else if (vs == "True")
                    {
                        btnSearch_Click(sender, e);
                        GridView1.DataBind();
                    }
                }
        
        }
