    public class MyComponentA
    {
         static MyComponentA()
         {
              // Check here.
              if (!MyLicensingHttpModule.IsLicensed)
              {
                  // Bomb the *type*.
                  throw new InvalidOperationException(
                      "MyComponentA is not licensed.");
              }
         }
    }
    public class MyComponentB
    {
         public MyComponentB()
         {
              // Or check on a per-instance basis.  You'd do
              // this if you needed properties on the class level
              // to be available regardless.  This is the
              // *less* likely scenario.
              if (!MyLicensingHttpModule.IsLicensed)
              {
                  // Bomb the *instance*.
                  throw new InvalidOperationException(
                      "MyComponentA is not licensed.");
              }
         }
    }
