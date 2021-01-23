        public void my_function(string some1, string some2)
        {
            .
            .
            da.InsertCommand cmd = New OleDbCommand("INSERT INTO [some] ([some1], [some2]) Values (@some1, @some2)", yourOleDbConnection);
            da.InsertCommand.Parameters.AddWithValue("@some1", some1);
            da.InsertCommand.Parameters.AddWithValue("@some2", some2);
            .
            .
            .
            .            
            .
            .
        }
