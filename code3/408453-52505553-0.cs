    // optionally abstract
    class MyClass {
       public int NonGenericProperty { get; set; } 
    }
    sealed class MyClass<T> : MyClass {
       public T GenericProperty { get; set; }
    }
