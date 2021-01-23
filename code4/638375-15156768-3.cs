    public class Deer : Animal
    {
        protected override void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "MovementSpeed")
            {
                Console.WriteLine("MovementSpeed changed");
            }
        
            // don't forget to call the base class otherwise the event will never get fired
            base.OnPropertyChanged(args);
        }
    }
