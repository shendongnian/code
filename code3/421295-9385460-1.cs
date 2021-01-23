    public class Car
    {
       ...
       public virtual Person Owner { get; protected set; }
       public void ChangeOwner(Person newOwner)
       {
              // perform validation and then 
              Owner = newOwner;
              // maybe perform some further domain-specific logic
       }
    }
