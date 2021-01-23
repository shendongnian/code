          public class B : A
          {
              public string p3{get;set};
              public void Hydrate{A a}
              {
                  this.p1 = a.p1;
                  this.p2 = a.p2;
               }
           }
    Then your code will be like this 
   
           B b = new B();
           b.Hydrate(a);
