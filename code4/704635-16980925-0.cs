    public class MyComparer:IEqualityComparer<Test>{
    //Equals and GetHashCode
    }
    
    var mergedList = list.Union(list2, new MyComparer()).ToList();
