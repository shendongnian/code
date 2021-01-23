System.Globalization.CultureInfo.GetCultureInfo(1033)
              .CompareInfo.GetStringComparer(CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth)
It comes from https://docs.microsoft.com/en-us/dotnet/api/system.globalization.globalizationextensions?view=netframework-4.8
It computes the hashcode correctly given the options given.
You'll still have to trim trailing spaces manually, as they as discarded by ANSI sql but not in .net
Here is a wrapper that trims spaces.
using System.Collections.Generic;
using System.Globalization;
namespace Wish.Core
{
    public class SqlStringComparer : IEqualityComparer<string>
    {
        public static IEqualityComparer<string> Instance { get; }
        private static IEqualityComparer<string> _internalComparer =
            CultureInfo.GetCultureInfo(1033)
                       .CompareInfo
                       .GetStringComparer(CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth);
        private SqlStringComparer()
        {
        }
        public bool Equals(string x, string y)
        {
            //ANSI sql doesn't consider trailing spaces but .Net does
            return _internalComparer.Equals(x?.TrimEnd(), y?.TrimEnd());
        }
        public int GetHashCode(string obj)
        {
            return _internalComparer.GetHashCode(obj?.TrimEnd());
        }
        static SqlStringComparer()
        {
            Instance = new SqlStringComparer();
        }
    }
}
