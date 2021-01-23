    using System.Linq;
    ...
    static bool IsValid(string str)
    {
      return str.All(c => c <= sbyte.MaxValue);
    }
