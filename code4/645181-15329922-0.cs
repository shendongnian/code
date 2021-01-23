    void Foo(){
        enTouchType outer = enTouchType.one;
        Example.enTouchType inner = Example.enTouchType.one;
        switch(outer){
            case enTouchType.one:
                Console.WriteLine("outer.one");
                break;
        }
        switch(inner){
            case  Example.enTouchType.one:
                Console.WriteLine("inner.one");
                break;        
        }
    }
