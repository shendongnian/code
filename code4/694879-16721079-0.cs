        //this will contain any properties you wanna send to the handler 
    public class MyHandlerEventArgs
    {
    }
    //this delegate gets the sender, you can change the sender type to be the encapsulated type of your controls
    public delegate void MyHandler(object sender, MyHandlerEventArgs args);
    //this is the class that fires the event in your case it will UI class I think
    public class  MyController
    {
        public event MyHandler myEvent;
        public void MyEvent_Fire()
        {
            if(myEvent != null)
                myEvent(this, new MyHandlerEventArgs());
        }
    }
    //here you can do your business logic for each control
    public class MyAction
    {
        MyController mc = new MyController();
        public MyAction()
        {
            mc.myEvent += new MyHandler(mc_myEvent);
        }
        void mc_myEvent(object sender, MyHandlerEventArgs args)
        {
            //check the sender type 
            //do your action
        }
    }
