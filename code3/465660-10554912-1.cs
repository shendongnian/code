    public static class LinqExtensions
    {
        public static IEnumerable<IEnumerable<T>> Transpose<T>(this IEnumerable<IEnumerable<T>> values)
        {
            if (!values.Any()) 
                return values;
            if (!values.First().Any()) 
                return Transpose(values.Skip(1));
    
            var x = values.First().First();
            var xs = values.First().Skip(1);
            var xss = values.Skip(1);
            return
             new[] {new[] {x}
               .Concat(xss.Select(ht => ht.First()))}
               .Concat(new[] { xs }
               .Concat(xss.Select(ht => ht.Skip(1)))
               .Transpose());
        }
    }
//Input: transpose [[1,2,3],[4,5,6],[7,8,9]]
//Output: [[1,4,7],[2,5,8],[3,6,9]]
var result = new[] {new[] {1, 2, 3}, new[] {4, 5, 6}, new[] {7, 8, 9}}.Transpose();     
