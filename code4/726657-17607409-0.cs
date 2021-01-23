    class GetStoreNumberFromNameAttribute : Attribute {
    }
    class Class1 {
        [GetStoreNumberFromName]
        public string store { get; set; }
    }
    class Validator<T>
    {
        public bool IsValid(T obj)
        {
            var propertiesWithAttribute = typeof(T)
                                          .GetProperties()
                                          .Where(x => Attribute.IsDefined(x, typeof(GetStoreNumberFromNameAttribute)));
            foreach (var property in propertiesWithAttribute)
            {
                if (!Regex.Match(property.GetValue(obj).ToString(), @"^\d+$").Success)
                {
                    property.SetValue(obj, Regex.Match(property.GetValue(obj).ToString(), @"\d+").Groups[0].Value);
                }
            }
            return true;
        }
    }
