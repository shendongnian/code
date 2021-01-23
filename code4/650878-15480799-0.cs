     private int _btnClickCount = 0;
     private void SomeButtonClicked(object sender, EventArgs args) {
         if (_btnClickCount == 0)
              // do something
         else if (_btnClickCount == 1)
              // do something else
         // etc.
         _btnClickCount++;
     }
         
