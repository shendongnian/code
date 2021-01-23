    public class NumberEventArgs : EventArgs
    {
       private int _number;
       public NumberEventArgs(int num)
       {
          this._number = num;
       }
        public int getNumber
        {
          get
          {
            return _reached;
          }
    }
    // eventhandler Method
    private void ShowMessage(object sender, NumberEventArgs e)
    {
     MessageBox.Show("Hello user your ticket no is:" + e.getNumber().ToString());
    }
     myRadioButton.CheckedChanged += (sender, e) =>{ ShowMessage(); }
     myRadioButton.CheckedChanged += (sender, e) => MessageBox.Show(string.Format("sender is: {0} and eventargumnet is:{1}",sender.getType(),e.toString()};
     myRadioButton.CheckedChanged += (sender, e) => string.Format("string = {0} and {1}", sender.getType() , e);
             
