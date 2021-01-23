    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    
    namespace CsharpLibrary
    {
       [Guid("C6659361-1625-4746-931C-36014B146679")]
       public class MyStringHolder : IStringHolder
       {
          String _text;
    
          public String GetText()
          {
             return this._text;
          }
    
          public void SetText(String value)
          {
             _text = value;
          }
          
       }
    }
