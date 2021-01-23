     if (PreviousPage != null)
            {
                if (((TextBox)PreviousPage.FindControl("TextBox1")) != null)
                {
                    string txtBox1 = ((TextBox)PreviousPage.FindControl("TextBox1")).Text;
                    Response.Write(txtBox1);
                }
            }
