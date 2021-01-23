    public class MyLabel : Label
    {
        public MyLabel()
        {
            if(this.Text == "something")
            {
                this.ForeColor = Color.Green;
            }
        }
    
        protected override void OnTextChanged(EventArgs e)
        {
            if(this.Text == "something")
            {
                this.ForeColor = Color.Green;
            }
        }
    }
