    public void button1_Click(object sender, EventArgs e)
    {
        // i do assume there is a class Form1 within your project?!
        Form1 frm = (Form1) Application.OpenForms["Form1"];
        // look for Project_list within your Form1.Controls, true to search all childControls too
        Control[] ctrls = frm.Controls.Find("Project_list", true);
        if (ctrls.Length >0)
        {
            ListBox LB =  ctrls[0] as ListBox;
            if (LB!=null)
                LB.Items.Add(Project_name.Text);           
            else
                System.Diagnostics.Debug.WriteLine("Doooooh");
        }
    }
