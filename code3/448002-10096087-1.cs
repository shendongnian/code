    public class A<TContent> where TContent : A_Content
    {
        public TContent Content { get; set; }
    } 
    
    public class B<TContent> : A<TContent> where TContent : B_Content
    {
       // nothing here, as the property is already defined above in A
    }
    
    public class C<TContent> : A<TContent> where TContent : C_Content
    {
       // nothing here, as the property is already defined above in A
    }
