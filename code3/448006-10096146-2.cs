    interface IA<out T>
    {
        T content { get; }
    }
    
    abstract class A<T> : IA<T>
        where T : A_Content
    {
        T content { get; set; }
    }
    class B : A<B_Content> {}
    class C : A<C_Content> {}
