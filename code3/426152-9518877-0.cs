    public class MyDateComparer : IComparer
    {
        int IComparer.Compare ( Object x, Object y )
        {
            // Cast x and y to your object type and then compare the dates. Return
            // -1, 0 or 1 depending on your comparison
            return ( ... );
        }
    }
    ...
    myList.Sort ( 0, myList.Length, new MyDateComparer () );
