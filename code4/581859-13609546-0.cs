    private void button1_Click(object sender, EventArgs e)
    {
        if (radioButton1.Checked == true)
        {
            objList1 = loadList();
            Form2 f2 = new Form2();
            for (int i = 0; i < objList1.Count; i++)
            {
                if (objList1[i] is UniversityStudents)
                {
                    UniversityStudents uStudents = (UniversityStudents)objList1[i];
                    
                    if (uStudents != null)
                    {
                        // do stuff
                    }
                    else
                    {
                        // do something sensible with the error here
                    }
                }
                // if clauses for the other "people" objects
                // ...
            }
            f2.FormClosed += new FormClosedEventHandler(childFormClosed);
            f2.Show();
            this.Hide();
        }
    }
