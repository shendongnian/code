    private void extProc_Exited(object sender, EventArgs e)
    {
         Process thisProc = (Process)sender;
         if(thisProc.ExitCode == 1)
         {
             // success
         }
         else 
         {
             // error encountered
         }
    }
