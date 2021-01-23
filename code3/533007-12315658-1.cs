    public class data
    {
        public List<installation> installations
    }
    
    public class installation : List<reader>
    {
        public void AddReader(reader obj)
        {
            this.Add(obj);
        }
    }
