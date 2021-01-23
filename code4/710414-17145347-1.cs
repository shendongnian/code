    private void BuildPredicate()
        {
            predicate = () =>
            {
                var t = typeof(T);
                var strProps = t.GetProperties().Count(p => p.PropertyType == typeof(string) && p.GetValue(this, null) != "X");
                var intProps = t.GetProperties().Count(p => p.PropertyType == typeof(int) && (int)p.GetValue(this, null) != 0);
                if (strProps == 0 && intProps == 0)
                {
                    return true;
                }
                return false;
            };
        }
        
