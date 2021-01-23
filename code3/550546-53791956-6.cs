    using System.Collections.Generic;
    using System.Linq;
    
    namespace YourProject.Extensions
    {
        public static class ListExtensions
        {
            public static bool SetwiseEquivalentTo<T>(this List<T> list, List<T> other)
                where T: IEquatable<T>
            {
                if (list.Except(other).Any())
                    return false;
                if (other.Except(list).Any())
                    return false;
                return true;
            }
        }
    }
