    public class Human
    {
        ...
        public List<Human> Parents
        {
            return new List<Human>(){Mother, Father}
        }
    
        public List<Human> Siblings()
        {
            List<Human> siblings = new List<Human>();
            foreach (var parent in Parents)
            {
                siblings.AddRange(Children);
            }
            return siblings;
        }
    }
    
    public class Man
    {
        public bool Check(ref List<Human> People, int Index)
        {
            foreach (var person in People)
            {
                // Can't marry your mother/father
                if (this.Parents.Contains(person)
                {
                     return false;
                }
                // Can't marry your sister/brother
                if (this.Siblings.Contains(person))
                {
                     return false;
                }
                // ... etc for other relationships
            }
        }
    }
