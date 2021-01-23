      private void Method1()
      {
          var obj=new TestClass();
          obj.TestMethod1(this);
      }
      public void TestMethod1(object caller=null,
                 [CallerMemberName] string callerName=null)
      {
           TestMethod2(caller??this,callerName??"TestMethod1");
      }
      private void TestMethod2(object caller=null,
                 [CallerMemberName] string callerName=null)
      {
          string callerName = ((caller??this).GetType().Name) + "." + callerName
          //get the calling class 
      }
