    public static MySqlConnection Connect() {
        OldCompatibility.BinaryAsString = true;
        MySqlConnection conn = new MySqlConnection("User id=root;pwd=root;port=3306;host=localhost;database=test");
        conn.Open();
    
        return conn;
    }
