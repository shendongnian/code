    private void button1_Click_1(object sender, EventArgs e)
    {
         //panel1.Visible = true;
            string value1 = button1.Text;
            switch(value1)
            {
                case "Expand":
                    panel1.Visible = true;
                    break;
                case "Reduce":
                    panel1.Visible = false;
                    break;
            }
            button1.Text = "Reduce";
            if(panel1.Visible==true)
            {
                button1.Text = "Reduce";
            }
            else if(panel1.Visible==false)
            {
                button1.Text = "Expand";
            }     
    }
