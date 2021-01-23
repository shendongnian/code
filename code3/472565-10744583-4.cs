    public class DataManager
    {
        public List<StudentData> Students { get; set; }
        // etc.
    }
    public class StudentData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // etc.
    }
    public class StudentEntryDialog : Form
    {
        public StudentData StudentData { get; set; }
        
        // ... code to call storeData method when user chooses to do so ...
        
        private void storeData()
        {
            StudentData = new StudentData();
            StudentData.FirstName = TextBox1.Text;
            StudentData.LastName = TextBox2.Text;
            // etc.
        }
    }
    public class CentralCodeOfSomeSort
    {
        private DataManager manager = new DataManager();
        
        private showStudentEntry()
        {
            StudentEntryDialog dialog = new StudentEntryDialog();
            dialog.ShowDialog();
            if (dialog.StudentData != null)
                manager.Students.Add(dialog.StudentData);
        }
    }
