    class Foo {
         private int bar;
        
         public Foo( int bar ){
             this.bar = bar;
         }
         public int Bar {
             get { return this.bar; }
         }
    }
    Foo foo = new Foo( 123 );
