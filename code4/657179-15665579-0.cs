    ObservableCollection<string> cost = 
        new ObservableCollection<string>((from i in context.Items
                                          where i.Cost != null
                                          && i.Cost > 0
                                          orderby i.Cost
                                          select i.Cost).Distinct()
                                                        .AsEnumerable()
                                                        .Select(c => c.ToString()));
