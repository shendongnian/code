    public class MyForm : Form
    {
        public A a = null;
        public MyForm ()
        {
            A = new A(this); // pass an instance of the MyForm to the class
        }
        public void WowMethod(){
           ... something amazing ...
        }
    }
    
    public class A
    {
       public MyForm associatedForm = null;
       
       public A( MyForm f ){
          associatedForm = f;
       }
       public void CallWowMethod()
       {
          associatedForm.WowMethod();
       }
    }
