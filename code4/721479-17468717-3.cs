    public void BindData()
        {
            try
            {
                gridtable.DataSource = Session["datasource "] ;
                gridtable.DataBind();
    
            }
            catch (Exception e)
            {
               //Do something
            }
        }
