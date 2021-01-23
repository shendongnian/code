    using System.Linq;
    double height = 0;
    // this will throw a exception if your list is empty
    var item = System.Linq.Enumerable.First(variable.Shapes);
    height = item.Height;
    // in case your list is empty, the item is null and no exception will be thrown
    var item = System.Linq.Enumerable.FirstOrDefault(variable.Shapes);
    if (item != null)
    {
         height = item.Height;
    }
