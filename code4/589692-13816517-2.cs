    if(dt.Rows.Count == 0)
    {
    	MessageBox.Show("Login Failed");
    	return;
    }
    
    string val = Convert.ToString(dt.Rows[0][3]);
    
    else if(val == "0")
    {
        this.Hide();
        StudentUI s = new StudentUI();
        s.Show();
    }
    else if (val == "1")
    {
        this.Hide();
        TeacherUI t = new TeacherUI();
        t.Show();
    }
    else if (val == "2")
    {
        FacultyUI f = new FacultyUI();
        f.Show();
    }
    else
    {
        MessageBox.Show("Login Failed");
    }
