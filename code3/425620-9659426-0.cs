    public class TestClassTypeDescriptor : ICustomTypeDescriptor
    {
       private TestClass mInst;
       public TestClassTypeDescriptor(TestClass inst)
       {
         mInst = inst;
       }
       //Implement ICustomTypeDescriptor
    }
    
    PropGridControl.SelectedObject = new TestClassTypeDescriptor(new TestClass());
