    public class Parsedata{
      public string[,] StringX{get;set;}
    }
    public class Caller{
      Parsedata p = new Parsedata();
      public void SetStringX(string[,] stringX){
        p.StringX = stringX;
      }
      public string[,] GetStringX(){
        return p.StringX;
      }
    }
