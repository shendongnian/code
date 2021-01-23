    public class sortByFNameHelper : IComparer
    {
       int IComparer.Compare(object a, object b)
       {
          UserName u1=(UserName)a;
          UserName u2=(UserName)b;
          if (u1.fName > u2.fName)
             return 1;
          if (u1.fName < u2.fName)
             return -1;
          else
             return 0;
       }
    }
