        public class MyForm : Form
        {
        //.ctor
        MyForm() { }
        
        private void ShowMyControl(){
          MyControl myControl = new MyControl();
          myControl.KeyboardKeyPressed += new Action<string>(OnMyControlKeyPressed);
          this.Controls.Add(myControl);
        }
        
        private void OnMyControlKeyPressed(string key)
        {
         switch(key)
          {
           case "D0" :
            DoSomething();
            break;
           case "D1" :
            DoSomethingElse();
            break;
           default :
            SendKeys(key);
            break;
          }
        }
    }
    
    /*MyControl*/
    
    namespace Keyboards
    {
      public class MyControl : Control
      {
            
        public event Action<string> KeyboardKeyPressed;
    
        private void HandlingMouseClick(Point PressedItem)
        {
            if(KeyboardKeyPressed != null)
               KeyboardKeyPressed(PressedItem.ToString());
        }
      }
    }
