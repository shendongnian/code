    public static List<T> SortedListWithLamda<T>(this List<T> list, string sortorder, string propertyname)
            {
                List<T> sortedlist = new List<T>();
                if (!string.IsNullOrEmpty(propertyname) && list != null && list.Count > 0)
                {
    
                    Type t = list[0].GetType();
    
                    if (sortorder == "A")
                    {
    
                        sortedlist = list.OrderBy(
                            a => t.InvokeMember(
                                propertyname
                                , BindingFlags.GetProperty
                                , null
                                , a
                                , null
                            )
                        ).ToList();
                    }
                    else
                    {
                        sortedlist = list.OrderByDescending(
                            a => t.InvokeMember(
                                propertyname
                                , BindingFlags.GetProperty
                                , null
                                , a
                                , null
                            )
                        ).ToList();
                    }
                }
                return sortedlist;
            }
