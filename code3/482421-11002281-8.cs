    public class MyuserControlEventArgs : EventArgs 
    {
        public bool ShouldHideUI { get;set;}
        public MyuserControlEventArgs (bool shouldHideUI) 
        {
             this.ShouldHideUI = shouldHideUI;
        }
    }
    public delegate void MyUserControlUpdateEventHandler(object sender, MyuserControlEventArgs e);
    public event MyUserControlUpdateEventHandler Update;
    protected void OnUpdate(MyuserControlEventArgs e)
    {
        if (Update!= null)
            Update(this, e);
    }
