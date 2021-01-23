    public class Control1 : UserControl {
       public delegate void ButtonClickHandler(object sender, EventArgs e);
       
       public ButtonClickHandler ButtonClickEvent {get;set;}
       
       public void Save(object sender, EventArgs e) {
          //do something
          if (ButtonClickEvent != null) {ButtonClickEvent(sender, e);}
          //do something
       }
    }
    public class Control2 : UserControl {
       protected override void OnLoad(EventArgs e) {
          control1.ButtonClickEvent += YourMethod;
       }
       
       protected void YourMethod(object sender, EventArgs e) { // do something here ... }
    }
