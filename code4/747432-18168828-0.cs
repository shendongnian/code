    public partial class Form1 : Form, IEqualityComparer<Students>
    {
      public bool Equals(Students x, Students y)
      {
         // your equal code
      }
      public int GetHashCode(Students obj)
      {
         //your getHashCode
      }
    }
