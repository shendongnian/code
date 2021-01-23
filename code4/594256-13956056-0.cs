    public abstract class Person { ... }
    public class Male : Person { ... }
    
    public class Female : Person { ... }
    public bool IsMatch(string needle, IEnumerable<Person> haystack)
    {
        var firstGirl = haystack.OfType<Female>().FirstOrDefault();
        var firstBuy = haystack.OfType<Male>().FirstOrDefault();
        return firstGirl != null &&
               firstGirl.Name == needle &&
               firstBoy != null &&
               firstBoy.Name != needle;
    }
