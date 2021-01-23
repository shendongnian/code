    public class MyuserControlEventArgs : EventArgs 
    {
        public MyuserControlEventArgs () 
        {
        }
    }
    public delegate void MyUserControlUpdateEventHandler(object sender, MyuserControlEventArgs e);
    public event MyUserControlUpdateEventHandler Update;
    protected void OnUpdate(MyuserControlEventArgs e)
    {
        if (Update!= null)
            Update(this, e);
    }
