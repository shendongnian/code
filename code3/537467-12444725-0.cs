    using MyAssembly;
    
    namespace MyNameSpace
    {
         Class MyClass
         {
              int MyValue1;
              int MyValue2;
    
              public MyClass(string myTypeName)
              {
                   string assemblyName = Assembly.GetAssembly(typeof(AbstractType)).ToString();
                   AbstractType selectedClass = (AbstractType)Activator.CreateInstance(assemblyName, myTypeName).Unwrap();
                   AssignInitialValues(selectedClass);
              }
    
              private void AssignInitialValues(AbstractType myClass)
              {
                   this.value1 = myClass.value1;
                   this.value2 = myClass.value2;
              }
          }
     }
