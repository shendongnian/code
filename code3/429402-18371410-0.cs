        private static bool CompareDictionaries(IDictionary<string, IEnumerable<string>> dict1, IDictionary<string, IEnumerable<string>> dict2)
        {
            if (dict1.Count != dict2.Count)
            {
                return false;
            }
            var keyDiff = dict1.Keys.Except(dict2.Keys);
            if (keyDiff.Any())
            {
                return false;
            }
            return (from key in dict1.Keys 
                    let value1 = dict1[key] 
                    let value2 = dict2[key] 
                    select value1.Except(value2)).All(diffInValues => !diffInValues.Any());
        }
