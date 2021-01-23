    class Originator 
    {
        private string state;
        // The class could also contain additional data that is not part of the
        // state saved in the memento.
 
        public void Set(string state) 
        {
            Console.WriteLine("Originator: Setting state to " + state);
            this.state = state;
        }
 
        public Memento SaveToMemento() 
        {
            Console.WriteLine("Originator: Saving to Memento.");
            return new Memento(state);
        }
 
        public void RestoreFromMemento(Memento memento) 
        {
            state = memento.SavedState;
            Console.WriteLine("Originator: State after restoring from Memento: " + state);
        }
 
        public class Memento 
        {
            public readonly string SavedState;
 
            public Memento(string stateToSave)  
            {
                SavedState = stateToSave;
            }
        }
    }
 
    class Caretaker 
    {
        static void Main(string[] args) 
        {
            List<Originator.Memento> savedStates = new List<Originator.Memento>();
 
            Originator originator = new Originator();
            originator.Set("State1");
            originator.Set("State2");
            savedStates.Add(originator.SaveToMemento());
            originator.Set("State3");
            // We can request multiple mementos, and choose which one to roll back to.
            savedStates.Add(originator.SaveToMemento());
            originator.Set("State4");
 
            originator.RestoreFromMemento(savedStates[1]);   
        }
    }
