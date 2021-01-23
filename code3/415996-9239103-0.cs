    public class Ingredient {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<RecipePart> RecipeParts { get; set; }
    }
    
    public class RecipePart {
        public int Id { get; set; }
        public Ingredient { get; set; }
        public Recipe { get; set; }
        // You'll want to think what unit this is meant to be in... another field?
        public decimal Quantity { get; set; }
    }
    
    public class Recipe {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<RecipePart> Parts { get; set; }
    }
