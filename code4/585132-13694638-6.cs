    public class PersonName
    {
        public string Name { get; set; }
    }
    
    public class GridData
    {
        public GridData()
        {
           Results = new ObservableCollection<PersonName>()
        }
        public ObservableCollection<PersonName> Results { get; set; }
    
        public void UpdateResults()
        {
            using (EntityDataModel be = new EntityDataModel())
            {
                // Just update existing list, instead of creating a new one.
               Results.Clear();
               be.tePersons.Select(x => new PersonName { Name = x.FirstName }).ToList().ForEach(item => Results.Add(item);
            }
        }
    }
