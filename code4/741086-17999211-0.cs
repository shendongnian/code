    public class MainClass{
          foo bar();
          more stuff {get;set;}
          ....
    }
    public class ExtendedClass:MainClass{
          protected class Helper:DynamicObject{ ...}
          private Helper _helper;
          public Extended(){
              _helper= new Helper(this);
          } 
          public dynamic Extend {
             get{ return _helper};
          }
    }
