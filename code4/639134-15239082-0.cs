     public static class Extensions
    {
        public async static Task<List<T>> In<T>(this IMobileServiceTable<T> table, List<int> ids)
        {
            var query = new StringBuilder("$filter=(");
            for (int i = 0; i < ids.Count; i++)
            {
                query.AppendFormat("id eq {0}", ids[i]); //don't forget to url escape and 'quote' strings
                if (i < ids.Count - 1)
                {
                    query.Append(" or ");
                }
            }
            query.Append(")");
            var list = await table.ReadAsync(query.ToString());
            var items = list.Select(i => MobileServiceTableSerializer.Deserialize<T>(i)).ToList();
            return items;
        }
    }
