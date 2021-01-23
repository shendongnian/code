    namespace Test1
    {
        public class NewGenerics<T> where T: IMyInterface, new()
        {
             private static T Create(int theInteger)
             {
                  var inst = new T();
                  inst.SetTheInteger(theInteger);
                  return inst;
             }
             ....
        }
    }
