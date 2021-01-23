     protected void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
     {
        try{
           t.Stop();
           MainActivity.RunOnUiThread(() => { button.Enabled = false; });
        catch(){
           Console.WriteLine("Exception: "+ex);       
        }
     }
