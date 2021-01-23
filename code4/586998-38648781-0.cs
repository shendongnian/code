    public class DescendingComparer<T>: IComparer<T> where T : IComparable<T>
    {
        public int Compare(T x, T y)
        {
            return y.CompareTo(x); //reverses, so compare ascending
                     //this is vs the standard method, which returns x.CompareTo(y)
        }
            
    }
        
    static void Main(string[] args)
    {
    SortedDictionary<float, string> myDict = new SortedDictionary<float,string>(new DescendingComparer<float>()); //sorts on the key
        string[] name = {"Bill", "Tom", "Susan", "Terry"};
        myDict.Add(.8f, name[0]);
        myDict.Add(.2f, name[1]);
        myDict.Add(.95f, name[2]);
        myDict.Add(.005f, name[4]);
        foreach (KeyValuePair<float, int> j in myDict)
        {
            Console.WriteLine("Key: {0}, Value: {1}",j.Key,j.Value);
        } //now it is stored in increasing order, so accessing largest elements fast
    }
