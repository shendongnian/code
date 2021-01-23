    public IEnumerable<T> FilterByValue<T>(List<int> value1Ids, IEnumerable<T> data, Func<T, int> selector)
    {
        if (value1Ids != null)
        {
            IEnumerable<ExampleData> dataQuery = null;
            foreach (int id in value1Ids)
            {
                int selectedId = id;
                if (dataQuery == null)
                {
                    dataQuery = data.Where(x => selector(x) == id);
                }
                else
                {
                    dataQuery = dataQuery.Union(data.Where(x => selector(x) == id));
                }
            }
            data = dataQuery;
        }
        return data;
    }
