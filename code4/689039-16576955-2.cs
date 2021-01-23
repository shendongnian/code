        private void button1_Click(object sender, EventArgs e)
        {
            List<Student> Students = ReturnAllStudentsList(); // Gets the list from JSON.
            foreach(Student student in Students)
            {
                // Here I can access to each student for every loop cycle.
                MessageBox.Show(student.Response);
            }
        }
