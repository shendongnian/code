    public class MyComparer : IComparer<MyObject>
    {     
        public int Compare(string s1, string s2)
        {
              var grad1 = s1.Replace('+','1').Replace('-','2');
              var grad2 = s2.Replace('+','1').Replace('-','2');             
              if (grad1 > grad2)
                  retun 1;
              else if (grad1 < grad2)
                  return -1;
              else
                  return 0;
        }
    }
    List<string> list = new List<string>{"A","A+","A-"};
    var sortedList = list.OrederBy(o=>o,new MyComparer()).OrderBy(o=>o.Length);
