    var query = from bug in RawListData
                group bug by new { bug.Category, bug.Priority } into grouped
                select new { 
                    Category = grouped.Key.Category,
                    Priority = grouped.Key.Priority,
                    Count = grouped.Count()
                };
