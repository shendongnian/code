    public class Button<T> where T : System.Windows.Forms.Control
    {
        T button;
    
        public Button(T button) 
        {
            this.button = button;
        }
    
        public void EnableButton(bool enable)
        {
            this.button.Enabled = enable;
        }
    }
