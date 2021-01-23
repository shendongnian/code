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
    
    public class Man : Human
    {
        public override bool Check(ref List<Human> People, int Index)
        {
            // Do basic checks first
            if (!base.Check(People, Index))
            {
                return false;
            }
            var person = People[Index];
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
            return true;   /// Not rejected... yes you can marry them... (if they want to!)
        }
    }
