    class ActivateAttributes
    {
        public ActivateAttributes(object source)
        {
            source.GetType()
                  .GetProperties()
                  .Where(x => x.GetCustomAttributes().OfType<DbField>().Any())
                  .ToList()
                  .ForEach(x => (x.GetCustomAttributes().OfType<DbField>().First() as DbField).GetInstance(x));
        }
    }
