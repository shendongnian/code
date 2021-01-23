    ISourceBlock<SomeClass> GetStuff() {
        var block = new BufferBlock<SomeClass>();
        Task.Run(async () =>
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                await conn.OpenAsync();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    SomeClass someClass;
                    // Create an instance of SomeClass based on row returned.
                    block.Post(someClass);
                }
            } 
        });
        return block;
    }
