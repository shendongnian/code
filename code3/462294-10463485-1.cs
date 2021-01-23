      public class TestB
      {
          private TestC C { get; set; }
          private ProcessDuration TD { get; set; }
          public TestB(ProcessDuration td)
          {
               this.TD = td;
               this.C = new TestC(td);
          }
          public void DoSomething()
          {
               this.TD.StartProcessMonitor( ... );
               this.C.DoSomethingEsle();
          }
      }
      public class TestC
      {
          private ProcessDuration TD { get; set; }
          public TestC(ProcessDuration td)
          {
              this.TD = td;
          }
          public void DoSomethingElse();
          {
              this.TD.StartProcessMonitor(...);  // or just continue using it???
          }
     }
