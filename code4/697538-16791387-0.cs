    protected void RequiredFieldValidator1_Load(object sender, EventArgs e)
    {
         if (CheckBox1.Checked == true)
         {
             RequiredFieldValidator1.Enabled = true;
         }
         else if (CheckBox1.Checked == false)
         {
             RequiredFieldValidator1.Enabled = false;
         }
    }
