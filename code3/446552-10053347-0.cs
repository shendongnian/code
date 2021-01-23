    using System.Collections.Generic;
    using System.Linq;
    List<int> list = new List<int>();
    List<int> sList = (from s in list
    where s.ToString().Contains("1")
    select s).ToList();
