        public static int Sum(this IEnumerable<int> source)
        {
            int num = 0;
            IEnumerator<int> Enumerator = source.GetEnumerator();
            while(Enumerator.MoveNext())
                num += Enumerator.Current;
            return num;
        }
