            var db = new SQLite.SQLiteAsyncConnection(DBPath);
            // Empty the Customer and Project tables 
            var customers = await db.Table<Customer>().ToListAsync();
            foreach (Customer customer in customers)
            {
                await db.DeleteAsync(customer);
            }
