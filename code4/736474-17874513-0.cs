    public class MyArray {
         string[] _storrage = new string[100];
         public string this[int index] {
             get { return _storrage[index]; }
             set { _storrage[index] = value; }
         }
    }
