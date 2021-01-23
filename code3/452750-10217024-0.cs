     interface I
     {
       int Prop { get; set; }
     }
    
     class A : I
     {
       int I.Prop { get; set; }
     }
    
     class B : A
     {
       public void Bar()
       {
         (this as I).Prop = 2;
       }
     }
    
     class C : B
     {
       public void Foo()
       {
         //Prop = 1;
       }
     }
