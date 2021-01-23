        public IEnumerable<T> Query<T>(T templateobject) {
            var sql = "SELECT * From " + typeof(T).Name + " Where ";
            var list = templateobject.GetType().GetProperties()
                 .Where(p => p.GetValue(templateobject) != null)
                 .ToList();
            int i = 0;
            Dictionary<string, object> dbArgs = new Dictionary<string, object>();
             
            list.ForEach(x =>
            {
                sql += x.Name + " = @" +  x.Name;
                dbArgs.Add(x.Name, x.GetValue(templateobject));
                if (list.Count > 1 && i < list.Count - 1) {
                    sql += " AND ";
                    i++;
                }
            });
            Debug.WriteLine(sql);
            return _con.Query<T>(sql, dbArgs).ToList();
        }
