    interface IIngredient 
    { 
        bool IsIngredient { get; }
        void DoIngredientStuff(); 
    } 
    
    class Recipe : IIngredient 
    { 
        public IEnumerable<IIngredient> Ingredients { get; set; } 
     
        bool IsIngredient {
           get { return true; // true if it is, false if it isn't }
        }   
    
        void DoIngredientStuff() 
        { 
          if (IsIngredient) {
            // do whatever
          }
        } 
    } 
