    public async static Task<List<T>> In<T>(this IMobileServiceTable<T> table,
         List<int> ids)
        {
            var query = new StringBuilder("$filter=(");
            for (int i = 0; i < ids.Count; i++)
            {
                query.AppendFormat("id eq {0}", ids[i]);
                if (i < ids.Count - 1)
                {
                    query.Append(" or ");
                }
            }
            query.Append(")");
            var list = await table.ReadAsync(query.ToString());
            List<T> items = new List<T>();
            foreach (var item in list)
            {
                items.Add(Newtonsoft.Json.JsonConvert.DeserializeObject<T>(item.ToString()));
            }
            return items;
        }
