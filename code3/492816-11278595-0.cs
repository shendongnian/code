    public class Pet
    {
        public string Name { get; set; }
        // other properties
    }
    public class PetComparer : Comparer<Pet> // 
    {
        public override int Compare(Pet x, Pet y)
        {
            if (x == null) return -1; // y is considered greater than x
            if (y == null) return 1; // x is considered greater than y
            return x.Name.CompareTo(y.Name);
        }
    }
 
