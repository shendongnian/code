       public static IEnumerable<T> RemoveBeforeAndAfter<T>(this IEnumerable<T> source, int percent, bool removeLast = false, bool removeFirst = false)
        {
            var enumerable = source as IList<T> ?? source.ToList();
            var sourceCount = enumerable.Count();
            var noRemove = Convert.ToInt32(Math.Ceiling((percent / 100D) * sourceCount));
            var remove = new List<T>();
            if (enumerable.Any())
            {
                if (removeLast)
                    remove.AddRange(enumerable.Reverse().Take(noRemove));
                if (removeFirst)
                    remove.AddRange(enumerable.Take(noRemove));
                return enumerable.Where(x => remove.Any(r => x.Equals(r))).ToList();
            }
            return default(IEnumerable<T>);
        }
