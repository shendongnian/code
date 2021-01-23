    protected void btnGetCount_Click(object sender, EventArgs e)
        {
    
            int countCB = 0;
            int countTB = 0;
            foreach (Control c in form1.Controls) //here is the minor change
            {
                if (c.GetType() == typeof(CheckBox))
                {
                    countCB++;
                }
                else if (c.GetType()== typeof(TextBox))
                {
                    countTB++;
                }
            }
    
            Response.Write("No of TextBoxes: " + countTB);
            Response.Write("<br>");
            Response.Write("No of CheckBoxes: " + countCB);
        } 
