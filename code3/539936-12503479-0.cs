    using System.Linq;
    double height = 0;
    // this will throw a exception if your list is empty
    var item = variable.Shapes.First(); 
    height = item.Height;
    // in case your list is empty, the item is null and no exception will be thrown
    var item = variable.Shapes.FirstOrDefault();
    if (item != null)
    {
         height = item.Height;
    }
