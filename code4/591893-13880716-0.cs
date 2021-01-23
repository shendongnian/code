    public class ButtonManager {
        private Button lastButton;
    	
    	public void SwitchTagWithText(Button button){
    	    string text = lastButton.Text;
            lastButton.Text = lastButton.Tag.ToString();
            lastButton.Tag = text;
    
            // Or whatever the logic is you need.
    	}
        public void ButtonClicked(Button button){
            this.SwitchTagWithText(button);
            // Or whatever the logic is you need.
        }
    }
