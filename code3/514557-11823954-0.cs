    public partial class CustomButton : Button {
        // My custom properties, constructor and events
     
        public CustomButton() 
        {  
             this.Text = this.Text.Replace("customButton ", "button");
        }
    }
