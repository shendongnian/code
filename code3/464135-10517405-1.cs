     static void Main(string[] args)
            {
                var sqlParent = "SELECT parentId as Id FROM ParentTable WHERE parentId=1;";
                var sqlChildOneSet = "SELECT Name FROM ChildOneTable;"; // Add an appropriate WHERE
                var sqlChildTwoSet = "SELECT Id, LocationName FROM ChildTwoTable;"; // Add an appropriate WHERE
    
                var conn = GetConnection() // whatever you're getting connections with
                using (conn)
                {
                    conn.Open();
                    using (var multi = conn.QueryMultiple(sqlParent + sqlChildOneSet + sqlChildTwoSet))
                    {
                        var parent = multi.Read<ParentObject>().First();
                        parent.ChildSetOne = multi.Read<ChildOne>().ToList();
                        parent.ChildSetTwo = multi.Read<ChildTwo>().ToList();
                    }
                }
            }
