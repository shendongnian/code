    public class MyButton<T> where T : System.Windows.Forms.Control
    {
        T button;
    
        public MyButton(T button) 
        {
            this.button = button;
        }
    
        public void EnableButton(bool enable)
        {
            this.button.Enabled = enable;
        }
    }
