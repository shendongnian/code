    private void button1_Click(object sender, EventArgs e)
    {
        object dude; // if you use inheritance then this could be of the base class's type
        if (this.checkEmployess.Checked)
        {
            // it's an employess
            Employess employee = new Employess();
            employess.Salary = textSalary.Text; // this copies the value of the control into your object
            employess.JobTitle = textJobTitle.Text; // however for this example we've assumed every control is a text control and your object has only string properties
            dude = employess;
        }
        else
        {
            // it's a member
            Members member = new Members();
            member.Name = textName.Text;
            member.Age = textAge.Text; // this in particular should be made numeric
            member.COB = textCOB.Text;
            dude = member;
        }
        MessageBox.Show(dude);
    }
