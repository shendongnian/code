    clsMainProjectLibrary
    {
      //This variable is set by the calling activity to check if user has opt for exiting the     application or actually application has crashed.
      public static bool isExit; 
      // My Global Application variable which get assigned when user successfully log-ins else is
      public static int intUserID; 
        public Intent ApplicationCrashHandler(Activity actForm)
        {
          if (clsFunctionaLibA.isExit == false)
          {
           Intent intentMyFirstForm = new Intent(actForm,typeof(actMyFistForm));
           intentMyFirstForm.SetFlag(ActivityFlags.ClearTop & ActivityFlags.NewTask);
           return intentMyFirstForm;
          }
          else
          {
           Intent blankIntent = new Intent();
           blankIntent.SetFlags(ActivityFlags.ClearTop);
           int intPID = Android.OS.Process.MyPid();
           Android.OS.Process.KillProcess(intPID);
           return null;
          }
        }
      }
