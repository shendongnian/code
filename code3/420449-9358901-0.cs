    // First, declare a few classes that implement the IComparer interface.
    public class CompareShirtSize : IComparer<string>
    {
        // Because the class implements IComparer, it must define a 
        // Compare method. The method returns a signed integer that indicates 
        // whether s1 > s2 (return is greater than 0), s1 < s2 (return is negative),
        // or s1 equals s2 (return value is 0). This Compare method compares strings. 
        public int Compare(string size1, string size2)
        {
            // Do size comarison here
        }
    }
    
    
    // The following method tests the Compare methods defined in the previous classes.
    public static void OrderByIComparer()
    {
        List<Unit> units;
    
         // Sort the elements of the array alphabetically.
        var sortedList = units.OrderBy(unit => unit.Size, new CompareShirtSize ());
    }
