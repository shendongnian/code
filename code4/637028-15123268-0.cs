    using System.Linq;
    ...
    foreach (CarBootSale obj in aList.Where(x -> x.Charity.ToLower() == "yes")
    {
        writer.WriteLine(obj.Display());
    }
