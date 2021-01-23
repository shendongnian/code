        public class CachedItems
        {
            private static List<dynamic> _priorityList = new List<dynamic>();
            public static List<dynamic> GetPriorityList()
            {
                if (_priorityList == null)
                {
                    // Load DB Items to the _priorityList, 
                    // if the app is multithreaded, you might wanna add some locks here
                    query = @"SELECT priorityid, label FROM prioritylist WHERE active = 'Y' ORDER BY theorder ASC";
                    parentfrm.prioritylist = db.localfetchrows(query);
                    if (cb != null)
                    {
                        using (var rows = db.localfetchrows(query))
                        {
                            while (rows.Read())
                            {
                                _priorityList.Add(new { 
                                                    PriorityId = int.Parse(rows["priorityid"].ToString()), 
                                                    Label = rows["label"].ToString() 
                                                  });
                            }
                        }
                    }
                }
                return _priorityList;
            }
        }
