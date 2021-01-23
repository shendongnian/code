    class A
    {
       public event Avtion<string> TextReady;
       
       private OnTextReady(string text)
       {
          var ev = TextReady;
          if(ev!=null) ev(text);        
       }
    }
    
    class Form1
    {
       private _a = new A();
       public Form1()
       {
          _a.TextReady+= (text)=> textBox.Text = text;
       }
    }
