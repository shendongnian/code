        public ICollection<T> getSortedData(ICollection<T> collection, string property, string direction)
        {
                    switch (direction.Trim())
                    {
                        case "asc":
                            collection = ((from n in collection
                                           orderby
                                               n.GetType().GetProperty(property).GetValue(n, null)
                                           select n).ToList<T>()) as ICollection<T>;
                            break;
                        case "desc":
                            collection = ((from n in collection
                                           orderby
                                               n.GetType().GetProperty(property).GetValue(n, null)
                                               descending
                                           select n).ToList<T>()) as ICollection<T>;
                            break;
                    }
                    return collection;
             }
