      createAAndBMethod1(Entities context)
      {
            A a = new A();
            B b = new B();
            a.b_fk = b;
            b.a_fk = a;
            context.As.AddObject(a);
      } 
    createAAndBMethod2(Entities context)
    {
            A a = new A();
            B b = new B();
            a.b_fk = b;
            context.As.AddObject(a);
            context.SaveChanges();
            b.a_fk = a;
            context.SaveChanges();    
    }
