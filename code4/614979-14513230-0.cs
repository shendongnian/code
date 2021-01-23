    class foo 
    { 
       public foo(String txt) : base(new MyInnerClass(txt)) { }
       private class MyInnerClass
       { 
           private string text;
           public MyInnerClass(string txt)
           { 
               this.text = txt;
           }
       }
    }
