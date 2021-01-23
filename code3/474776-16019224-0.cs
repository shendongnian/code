    if (PreviousPage != null)
        {
            string name = ((TextBox)PreviousPage.FindControl("TextBox1")).Text.ToString();
            Response.Write(name);
        }
