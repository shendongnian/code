    public class ButtonStateDown : ButtonState
    {
        Button button;
        public ButtonStateDown(Button button)
        {
            this.button = button;
        }
        public void CheckForInput()
        {
            //...
            //Check for user input, fire the event of the button and change the state
            //...
            if(Click != null)
                Click(new MouseEventArgs(mouse.X, mouse.Y))
            button.State = new ButtonStateNormal(button);
        }
    }
