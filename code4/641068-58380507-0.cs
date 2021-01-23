                context.Database.ExecuteSqlCommand("delete from TableA");
                context.Database.ExecuteSqlCommand("delete from sqlite_sequence where name='TableA'");//resets the autoindex
                context.Database.ExecuteSqlCommand("delete from TableB");
                context.Database.ExecuteSqlCommand("delete from sqlite_sequence where name='TableB'");//resets the autoindex 
                context.Database.ExecuteSqlCommand("delete from TableC");
                context.Database.ExecuteSqlCommand("delete from sqlite_sequence where name='TableC'");//resets the autoindex 
