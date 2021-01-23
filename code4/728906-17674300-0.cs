    public class UserControlsBackgroundEventArgs
    {
      public string output;
      public UserControlsBackgroundEventArgs(string up)
      {
         output = up;
      }
    }
    public delegate void UserControlsBackgroundOutputHandle(UserControlsBackgroundEventArgs e);
    public class testEvent
    {
      public event UserControlsBackgroundOutputHandle UserControlsBackgroundOutput;
      public void DoSomeThings()
      {
         // do some things
         if (UserControlsBackgroundOutput != null)
         {
            string str = "test1";
            UserControlsBackgroundEventArgs arg = new UserControlsBackgroundEventArgs(str);
            UserControlsBackgroundOutput(arg); // you've done that with str, whitch makes me
                                              // you don't know what the event param is
         }
      }
    }
    public class test
    {
      private testEvent myTest;
      private const string CLICKNAME = "whatever"; // i don't know what you want here
      public test()
      {
         myTest = new testEvent();
         myTest.UserControlsBackgroundOutput += UserControlsBackgroundOutput;
      }
      void UserControlsBackgroundOutput(UserControlsBackgroundEventArgs e)
      {
         if (CLICKNAME == e.output)
            return;
         if (e.output == "test1")
         {
         }
      }
    }
