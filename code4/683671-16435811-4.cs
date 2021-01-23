    public class MainForm : Form
    {
       public MainForm()
       {
          sdkcommunication.RaiseCustomEventHandler1 += new  EventHandler<CustomEventHandler1>(sdkcommunication_RaiseCustomEventHandler1);
       }
       void sdkcommunication_RaiseCustomEventHandler1(object sender, CustomEventHandler1 e)
       {
          //Do something. 
       }
    }
