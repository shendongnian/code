    [Test]
    public void ShouldDisplayMainForm() {
       using( var wrapper = new WhiteWrapper( MYAPP_PATH ) ){
           WaitHandle handle = new ManualResetEvent(false);
           Window win = wrapper.GetWindow( "MYAPP_MAIN_FORM_TITLE" );
           win.Loaded += (sender, e) => handle.set(); //Loaded or Onload, depending on framework
           handle.WaitOne();
           Assert.IsNotNull(win);
       }
    }
