    public class UpperCaseableTextbox : Textbox, ISupportUpperCase {
      
      public bool AlwaysInUpperCase { get; set }
      //constructor
      public UpperCaseableTextbox () {
         this.TextChanged += (sender, args) => {
            if (this.AlwaysInUpperCase) {
               int pos = this.SelectionStart;
               this.Text = this.Text.ToUpper();
               this.SelectionStart = pos;
            }
         }
      }
    }
