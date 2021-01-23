     var manager = new DataTableManager(); 
     var student = new Student {
         FirstName = firstNameTextBox.Text;
         LastName = lastNameTextBox.Text;
         ID = Int32.Parse(IdTextBox.Text);
     };
     manager.SchoolInfo.Add(student);  
