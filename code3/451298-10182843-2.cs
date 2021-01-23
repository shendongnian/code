    public static class EnumeratorExt {
        public static T Next<T> (this IEnumerator<T> seq) {
            if (seq.MoveNext()) {
                return seq.Current;
            }
            return default(T);
        }
    }
    // Now call it like so!
    using (var generator = Twist(5, 10).GetEnumerator()) {
        Console.WriteLine(generator.Next());
        Console.WriteLine(generator.Next());
        Console.WriteLine(generator.Next());
        Console.WriteLine(generator.Next());
    }
