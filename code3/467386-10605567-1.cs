    Form2:Form
    {
      public Form1 Parent { set;get;}
      public Form2(Parent parent) 
      { 
        this.Parent =parent;
      }    
    }
