    public class State
    {
       public string Name { get; private set; }
    
       private State(string name)
       {
          this.Name = name;
       }
    
       public State CreateState(string name)
       {
          // validate and throw error if invalid
          return new State(name);
       }
    }
