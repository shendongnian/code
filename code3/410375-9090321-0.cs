       public class CustomList : IEnumerable<int>
       {
          readonly List<int> list = new List<int>{1,2,3,4};
          private int now = 0;
    
          public void Add(int n)
          {
             list.Add(n);
          }
    
          public IEnumerator<int> GetEnumerator()
          {
             while (now<list.Count)
             {
                yield return list[now];
                now++;
             }
          }
    
          IEnumerator IEnumerable.GetEnumerator()
          {
             return GetEnumerator();
          }
       }
