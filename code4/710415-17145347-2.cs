    private void BuildPredicate()
        {
            predicate = (obj) =>
            {
                var t = typeof(T);
                var strProps = t.GetProperties().Count(p => p.PropertyType == typeof(string) && p.GetValue(obj, null) != "X");
                var intProps = t.GetProperties().Count(p => p.PropertyType == typeof(int) && (int)p.GetValue(obj, null) != 0);
                if (strProps == 0 && intProps == 0)
                {
                    return true;
                }
                return false;
            };
        }
