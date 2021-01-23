    var lengthComparer = ProjectionEqualityComparer.Create((String s) => s.Length);
    Console.WriteLine(lengthComparer.Equals("foo", "bar"));  // true
    Console.WriteLine(lengthComparer.Equals("biz", "baaz")); // false
    var nameComparer = ProjectionEqualityComparer.Create((Person p) => p.Name);
    var dict = new Dictionary<Person, int>(nameComparer);
