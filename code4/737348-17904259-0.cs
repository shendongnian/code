      abstract class cbase
      {
        internal string _var1 = "def1", _var2 = "def2";
    
        public override string ToString()
        {
          return string.Format("{0} - {1}", _var1, _var2);
    
        }
      }
      class cchild1 : cbase
      {
    
        public cchild1()
        {
          _var1 = "umm";
          _var2 = "ok";
    
        }
      }
      class cchild2 : cbase
      {
    
      }
