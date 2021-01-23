        private static bool Any<T>(IEnumerable<T> list)
        {
            using (var enumerator = list.GetEnumerator())
            {
                return list.GetEnumerator().MoveNext();
            }
        }
