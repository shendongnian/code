      public class SuperRadioButton : RadioButton
      {
        private bool showFocusCues = false;
        protected override void InitLayout()
        {
          this.GotFocus += (sender, args) =>
          {
            showFocusCues = true;
          };
          this.LostFocus += (sender, args) =>
          {
            showFocusCues = false;
          };
        }
        protected override bool ShowFocusCues
        {
          get
          { 
            return showFocusCues;
          }
        }
      }
