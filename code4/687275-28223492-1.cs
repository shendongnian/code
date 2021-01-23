    [Activity(Label = "Profile Details",MainLauncher=false)]
     public class actMyCustomActivity : Activity
     {
       clsMainProjectLibrary objMainProjectLibrary = new clsMainProjectLibrary();
       protected override void OnCreate(Bundle bundle)
       {
         // Put your all code here... what u want
       }
    
       protected override void OnResume()
       {
        if (clsMainProjectLibrary.intUserID == 0)
        {
          StartActivity(objMainProjectLibrary.ApplicationCrashHandler(this));
        }
        base.OnResume();
       }
    
       public override bool OnCreateOptionsMenu(IMenu menu)
       {
         //here you have your exit Menu.
       }
    
       public override bool OnOptionsItemSelected(IMenuItem item)
       {
         //code for user clicking on Exit.
         :
         :
         case 'Exit' : 
                      clsFunctionaLibA.isExit = true;
                      int intPID = Android.OS.Process.MyPid();
                      Android.OS.Process.KillProcess(intPID);
    
         :
         :
       }
     }
