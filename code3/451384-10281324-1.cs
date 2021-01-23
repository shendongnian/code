            List<int> mContactIDs = new List<int>();
            using (var db = new Entities())
            {
                string queryString = @"
                                    SELECT  
	                                    VALUE H.EntryID
                                    FROM    
	                                    Entities.ActionLog AS H
                                    WHERE 
	                                    H.ID IN (
		                                    SELECT VALUE TOP (1) Hi.ID
		                                    FROM Entities.ActionLog AS Hi
		                                    WHERE Hi.ActionType.ID = 1
		                                    AND Hi.TableName = 'Kontakt'
		                                    AND Hi.EntryID = H.EntryID
		                                    ORDER BY Hi.Date	
	                                    )
                                    {0}
                                    GROUP BY H.EntryID";
                List<string> lDepartments = new List<string>();
                foreach (var dep in b.DepartmentList)
                {
                    lDepartments.Add(string.Format(" H.Person LIKE '%{0}' ", dep.Value));
                }
                string sDepartmentQuery = string.Empty;
                if (lDepartments.Count > 0)
                {
                    sDepartmentQuery = string.Format(" AND ({0}) ", string.Join(" OR ", lDepartments.ToArray()));
                }
                var result = db.CreateQuery<int>(string.Format(queryString, sDepartmentQuery));
                if (result != null && result.Count() > 0)
                {
                    mContactIDs = result.ToList();
                }
            }
