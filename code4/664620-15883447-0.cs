    static void Main()
    {
    ...
    MainForm mainFrom = new MainForm();
    mainFrom.FormClosed += QuitLoop;
    mainFrom.Show();
    do
    {
         Application.DoEvents();
         mainFrom.glControl1.Invalidate(true); //actually may program is a lot more complex than this
         if (mainFrom.IsRunning)
              System.Threading.Thread.Sleep(0);
         else
              System.Threading.Thread.Sleep(1);
    } while (!mQuit);
    
    ...
