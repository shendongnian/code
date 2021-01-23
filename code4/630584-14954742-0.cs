    public IEnumerable<object> GetAllTasks(string[] fields)
    {
        List<object> response = new List<object>();
        Tasks.ForEach((a) =>
        {
            dynamic expando = new ExpandoObject();
            var p = expando as IDictionary<String, object>;
            foreach (string item in fields)
            {
                p[item] = a.GetType().GetProperty(item).GetValue(a);
            }
            response.Add(expando);
        });
        return response;
    }
