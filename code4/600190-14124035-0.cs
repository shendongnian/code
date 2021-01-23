       string prop1;
       string prop2;
    
       string Prop1 
       {
          get { return prop1;}
          set 
          {
             if (!( Prop2 == "Test2" && value == "Test1"))
             {
                 Prop1 = value;
              }
             ... Add other condition here
          }
       }
       
       string Prop2
       {
          get { return prop1;}
          set 
          {
             // set Prop2 based on Prop1
           }
       }
