    Student student1;  //**Simple Declare it here then**
    private void button3_Click(object sender, EventArgs e)
        {
      
            student1 = new Student(); //**Create a new instance here**
            **//BUT You need to handle the exception that can come if the user clicks //button1   before button 3** possibly like this
             if(student1 == null)
                     return;
            label1.Text = student1.text();
            if (student1.hasPassed() == true)
            {
                passfailtextbox.Text = "Pass";
            }
            else
            {
                passfailtextbox.Text = "Fail";
            }
        }
    
    private void button1_Click(object sender, EventArgs e)
        {
            Student student1 = new Student();
            student1.FirstName = firstnamebox.Text;
            student1.SecondName = secondnamebox.Text;
            student1.DateofBirth = DateTime.Parse(dobtextbox.Text).Date;
            student1.Course = coursetextbox.Text;
            student1.MatriculationNumber = int.Parse(matriculationtextbox.Text);
            student1.YearMark = double.Parse(yearmarktextbox.Text);
    
        }
