    private void button1_Click(object sender, EventArgs e)
    {
        student1.FirstName = firstnamebox.Text;
        student1.SecondName = secondnamebox.Text;
        student1.DateofBirth = DateTime.Parse(dobtextbox.Text).Date;
        student1.Course = coursetextbox.Text;
        student1.MatriculationNumber = int.Parse(matriculationtextbox.Text);
        student1.YearMark = double.Parse(yearmarktextbox.Text);
        if(student1.IsValid())
        {
            // good
        }
        else
        {
            // bad
        }
    }
