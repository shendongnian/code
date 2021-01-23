    public class MyDataProvider
    {
        bool isDataLoaded = false;
    
        public void LoadData(String sql, Hashtable data)
        {
            // Load data.
            isDataLoaded = true; // Or whatever mechanism you want to use to ensure data is loaded.
        }
    
        public IEnumerable<Student> GetStudents()
        {
            // Process student data if isDataLoaded.    
        }
    
        public IEnumerable<Teacher> GetTeachers()
        {
            // Process teacher data if isDataLoaded.
        }
    }
