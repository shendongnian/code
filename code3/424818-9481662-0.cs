        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Add and event RowDataBound
                grvGrid.RowDataBound += new GridViewRowEventHandler(grvGrid_RowDataBound); 
            }
            catch
            {
                //...throw
            }
        }
        protected void grvGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {                
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    //...
                }
                if (e.Row.RowType == DataControlRowType.DataRow)
                {          
                    //Add an ImageButton foreach row in GridView
                    ImageButton ibtImageAlt = new ImageButton();
                    ibtImageAlt.ImageUrl = "App_Images/y.gif";
                    //ImageButton's ID will be the index of the row
                    ibtImageAlt.ID = e.Row.RowIndex.ToString();                    
                    ibtImageAlt.ForeColor = System.Drawing.Color.White;
                    ibtImageAlt.Font.Overline = false;
                    ibtImageAlt.Click += ibtImageAlt_Click;
                }
            }
            catch
            {
            //...throw
            }
        }
        protected void ibtImageAlt_Click(object sender, EventArgs e)
        {
            try
            {
                //Catch the ImageButton ID and the row in GridView
                
                //An example to catch the value of the row selected by the ImageButton
                Int32 intIndexRow = Convert.ToInt32(((ImageButton)sender).ID);
                String strTest = grvGrid.Rows[intIndexRow].Cells[0].Text;
            }
            catch
            {
                //...throw
            }
        }
