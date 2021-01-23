    public static List<string> GetPropertiesToLogWithCaching(object obj)
        {
            List<string> propertiesToLog = new List<string>();
            if (obj != null)
            {
                string key = obj.GetType().FullName;
                propertiesToLog = CacheLayer.Get<List<string>>(key);
                if (propertiesToLog == null)
                {
                    propertiesToLog = GetPropertiesToLog(obj);
                    CacheLayer.Add<List<string>>(propertiesToLog, key);
                }
            }
            return propertiesToLog;
        }
        public static List<string> GetPropertiesToLog(object obj)
        {
            List<string> propertiesToLog = new List<string>();
            if (obj != null)
            {
                foreach (var p in obj.GetType().GetProperties().Where(prop => !Attribute.IsDefined(prop, typeof(NoLogAttribute))))
                {                   
                    propertiesToLog.Add(p.Name);
                }
            }
            return propertiesToLog;
        }
