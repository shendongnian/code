    class MyForm : Form
    {
        Database db;
        public Form()
        {
            db = new Database(this);
        }
        public void DoSomething()
        {
            var errors = db.Login("", "");
            if (errors.Any())
                label1.Text = errors.First(); // Or you can display all all of them
        }
    }
    class Database
    {    
        public List<string> Login(string username, string password)
        {
            var errors = new List<string>();
    
            if (string.IsNullOrEmpty(username))
                errors.Add("Username is required");
            
            if (string.IsNullOrEmpty(password))
                errors.Add("Password is required");
    
            [...]
            return errors;
        }
    }
