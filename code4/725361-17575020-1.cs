    using System.Linq;
    object list1 = new List<string>() { "a", "b" };
    object list2 = new List<bool?>() { true, false };
    IEnumerable<object> bind1 = list1.Cast<Object>();
    IEnumerable<object> bind2 = list2.Cast<Object>();
