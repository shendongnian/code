    public class MyButton<T> where T : System.Windows.Forms.ToolStripItem
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
