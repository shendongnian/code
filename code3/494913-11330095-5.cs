     // Build up a non-materialized IQueryable<>
     var usersQuery = db.Users;
     if (!string.IsNullOrEmpty(userID))
     {
           usersQuery = usersQuery.Where(u => u.Name == userId);
     }
     // Of course, you wouldn't dream of storing passwords in cleartext.
     if (!string.IsNullOrEmpty(anotherField))
     {
           usersQuery = usersQuery.Where(u => u.AnotherColumn == anotherField);
     }
     ...
     // Materialize (and execute) the query
     var filteredUsers = usersQuery.ToList();
