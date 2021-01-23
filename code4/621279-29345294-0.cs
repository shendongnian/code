    class A {
        A(int i){ ... }
    }
    class B { ... }
    public void MyMethod<T>(){
        T t = new T(); //This would be fine if you use 'MyMethod<B>' but you would have a problem calling 'MyMethod<A>' (because A doesn´t have a parameterless construtor;
    }
