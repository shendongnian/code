    using System.Linq;
    ...
    foreach (var obj in aList.Where(x -> x.Charity.ToLower() == "yes")
    {
        writer.WriteLine(obj.Display());
    }
