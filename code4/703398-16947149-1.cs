    [Test]
    public void ShouldDisplayMainForm() {
       using( var wrapper = new WhiteWrapper( MYAPP_PATH ) ){
           Window win = wrapper.GetWindow( "MYAPP_MAIN_FORM_TITLE" );
           While (win.IsHandleCreated)
             Thread.Sleep(1000);
           Assert.IsNotNull(win);
       }
    }
