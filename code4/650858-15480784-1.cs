    public class A{  public void DoSomething(){} }
    public class B{  public void DoSomethingElse(){}}
    public class C{  public void DoAnything(){}}
    public interface ID 
    { 
        void A_DoSomething(); 
        void B_DoSomethingElse(); 
        void C_DoAnything(); 
    }
    public class D : ID 
    { 
        private A a;
        private B b;
        private C c;
        public D(A a,B b, C c) { this.a=a;this.b=b;this.c=c; }
        public void A_DoSomething(){ a.DoSomething();} 
        public void B_DoSomethingElse(){ b.DoSomethingElse();}
        public void C_DoAnything(){ c.DoSomething();
    }
