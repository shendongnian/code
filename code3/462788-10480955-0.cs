    public class ColumnComparer : IEqualityComparer<string> {
         private static readonly string[] remove = {"(",")"," ","-"};
         public bool Equal(string x, string y){
              //remove ignorable characters;
              var tempX = string.Concat(x.Split(remove,StringSplitOptions.IgnoreEmptyEntries));
              var tempY = string.Concat(y.Split(remove,StringSplitOptions.IgnoreEmptyEntries));
              return tempX == tempY;
         }
    
         public int GetHashCode(string x){
              return string.Concat(
                   x.Split(remove,StringSplitOptions.IgnoreEmptyEntries)
                   ).GetHashCode();
         }
    }
