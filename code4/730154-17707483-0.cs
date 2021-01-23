    public class StateList : List<Type>
    {
         public override void Add(Type t)
         {
             if (typeof(t).IsSubclassOf(typeof(State))
             {
             }
             else
                 throw new InvalidArgumentException();
         }
    }
