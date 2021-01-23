    private void Button1Click(object sender, EventArgs e)
    {
    thread cThread=new thread(th);
    cThread.start();
    while(true)
    {
      // do any thing
      textbox.Invalidate();
      Application.DoEvents(); // Releases the current thread back to windows form
                              // NOTE Thread sleep different in Application.DoEvents();
                              //Application.DoEvents() is available only in System.Windows.Forms
    }
    } 
