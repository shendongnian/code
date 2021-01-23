    ///AppTest.cs
    [Test]
    public void ShouldDisplayMainForm() {
       using( var wrapper = new WhiteWrapper( MYAPP_PATH ) ){
           Window win = wrapper.GetWindow( "MYAPP_MAIN_FORM_TITLE" );
           Assert.IsNotNull(win);
           win.WaitTill( ()=> win.IsCurrentlyActive );
       }
    }
