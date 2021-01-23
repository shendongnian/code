    private class Foo
    {
       private int _i; // variable is captured by delegate
    
       public int Bar(int x)
       {
           _i = _i + 1; // thats why it has new value on next call
           return _i;
       }
    }
