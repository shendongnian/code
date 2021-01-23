    public class AnyClass
    {
        public AnyClass(Animal anAnimal)
        {
            TheAnimal = anAnimal;
            anAnimal += Animal_PropertyChanged;
        }
        
        public Animal TheAnimal { get; private set; }
    
        private void Animal_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "MovementSpeed")
            {
                Console.WriteLine("MovementSpeed changed"); 
            }
        }
    }
