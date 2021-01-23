    public class User
    {
        private string m_Age;
        private string m_Height;
       
        public User() { }
        
        public string Age
        {
            get { return m_Age; }
            set { m_Age = value; }
        }
        public string Height
        {
            get { return m_Height; }
            set { m_Height = value; }
        }
    }
----------------------------------------
    var rows = new List<User>();
    while (reader.Read())
    {
         var row = new User();
         row.Age = reader["age"];
         row.Height = reader["height"];
         rows.Add(row);
    }
    res.rows = rows; //if the res.rows property is an array then you can change this line to res.rows = rows.ToArray();
    return res;
