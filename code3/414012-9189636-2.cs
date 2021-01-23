    // set up connection string
    string connectionString = "server=.;database=test;integrated Security=SSPI;";
    // define a CTE (Common Table Expression) to recursively build your hierarchical
    // structure into a flat list and order it according to its "sequence" (root first)
    string cteStatement =
                @";WITH Hierarchy AS
                  (
                     SELECT
                        ID,  ParentID = CAST(NULL AS INT),
                        Name, HierLevel = 1
                     FROM
                        dbo.HierarchyTest   -- replace with your table name!
                     WHERE
                        ParentID IS NULL
		
                     UNION ALL
	
                     SELECT
                        ht.ID, ht.ParentID, ht.Name, h1.HierLevel + 1
                     FROM
                        dbo.HierarchyTest ht   -- replace with your table name!
                     INNER JOIN 
                        Hierarchy h1 ON ht.ParentID = h1.ID
                  )
                  SELECT Id, ParentId, Name
                  FROM Hierarchy
                  ORDER BY HierLevel, Id";
    // set up list of "Unit" objects
    List<Unit> units = new List<Unit>();
    
    // create connection and command to query             
    using(SqlConnection conn = new SqlConnection(connectionString))
    using(SqlCommand cmd = new SqlCommand(cteStatement, conn))
    {
        conn.Open();
        // use SqlDataReader to iterate over results
        using(SqlDataReader rdr = cmd.ExecuteReader())
        {
            while(rdr.Read())
            {
                // get the info from the reader into the "Unit" object
                Unit thisUnit = new Unit();
                thisUnit.Id = rdr.GetInt32(0);
                thisUnit.Name = rdr.GetString(2);
                thisUnit.Children = new List<Unit>();
                // check if we have a parent
                if(!rdr.IsDBNull(1))
                {
                    // get ParentId
                    int parentId = rdr.GetInt32(1);
                    // find parent in list of units already loaded
                    Unit parent = units.FirstOrDefault(u => u.Id == parentId);
                    // if parent found - set this unit's parent to that object
                    if(parent != null)
                    {
                        thisUnit.Parent = parent;
                        parent.Children.Add(thisUnit);
                    }
                }
                else
                {
                    units.Add(thisUnit);
                }
            }
        }
        conn.Close();
    }
