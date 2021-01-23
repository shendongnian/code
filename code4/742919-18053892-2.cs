    class Column
    {
      string plainText;
      Regex reg = new Regex(@"(Source\b\w+\b\w+\b)(Destination\b\w+\b\w+\b)");
      public Source Source {
        get {
            Match m = reg.Match(plainText);
            Group source = m.Groups[0];
            string[] s = source.Value.Split(new string[]{" "}, StringSplitOptions.RemoveEmptyEntries);
            return m.Success ? new Source(new string[]{s[1],s[2]}) : null;
        }
        set {
            Match m = reg.Match(plainText);
            Group dest = m.Groups[1];
            if(m.Success) plainText = value + " " + dest.Value;            
        }
      }
      public Destination Destination { 
        get {
            Match m = reg.Match(plainText);
            Group dest = m.Groups[1];
            string[] s = dest.Value.Split(new string[]{" "}, StringSplitOptions.RemoveEmptyEntries);
            return m.Success ? new Destination(new string[]{s[1], s[2]}) : null;
        }
        set {
            Match m = reg.Match(plainText);
            Group source = m.Groups[0];
            if(m.Success) plainText = source.Value + " " + value;
        }
      }
      //This is used to change the plainText
      //for example: SetPlainText("Source home(1) type[3] Destination NewYork(3) Seattle[2]");
      public void SetPlainText(string txt){
        plainText = txt;
      }
    }
    public class Source
    {
      public Source(string[] s){
         Name = s[0];
         Type = s[1];
      }
      public string Name { get; set; }
      public string Type { get; set; }
      public override string ToString(){
         return string.Format("Source {0} {1}",Name,Type);
      }
    }
    public class Destination
    {
      public Destination(string[] s){
        Name = s[0];
        Type = s[1];
      }
      public string Name { get; set; }
      public string Type { get; set; }
      public override string ToString(){
         return string.Format("Destination {0} {1}",Name,Type);
      }
    }
