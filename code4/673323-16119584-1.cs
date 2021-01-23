    public class DerivedAdder : MyAdder, ICanAdd
    {
      int ICanAdd.Add(int x, int y)
      {
        return base.Add(x, y);
      }
    }
   
    ...
    MyAdder myAdder = new DerivedAdder();
    var iCanAdd = (ICanAdd)myAdder; // Valid in this case
    int sum = iCanAdd.Add(2, 2);    // sum = 4
