    using System.Linq;
    string match = Producttext2.FirstOrDefault((x) => x.Contains(Producttext));
    if (match != null)
    {
     // do stuff
    }
    else
    {
     // error message
    }
