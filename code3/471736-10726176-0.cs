    public class CustomClass
    {
     [CustomAttribute]
     public dynamic value { get; set; }
    }
    public class MyClass
    {
        public CustomClass m_nVar1, var2, var3;
        public MyClass()
        {
            m_nVar1.value = (int)m_nVar1.value;
            var2.value = (string)var2.value;
        }
    }
    
