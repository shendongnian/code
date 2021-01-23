    class BaseProcessor
    {
        System.Windows.Forms.Button myButton;
        public System.Windows.Forms.Button MyButton
        {
            get
            {
                return myButton;
            }
            set
            {
                myButton = value;
                myButton.Click += new System.EventHandler(this.MyButton_Click);
           }
        }
        public BaseProcessor()
        {
        }
        public virtual void MyButton_Click(object sender, EventArgs e)
        {
        }
