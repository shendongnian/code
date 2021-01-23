            List<Dto> groups =
                context.tableName.GroupBy(e => e.unit)
                     .Select(
                         e =>
                         new Dto
                             {
                                 DateTime = e.GetEnumerator().Current.date,
                                 Message = e.GetEnumerator().Current.message,
                                 Unit = e.GetEnumerator().Current.unit,
                                 Count = e.Count()
                             })
                     .ToList();
