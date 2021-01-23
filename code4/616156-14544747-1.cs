    public partial class MyUserControl
    {
        public event EventHandler<MyEventArgs> ButtonClicked;
    
        public MyUserControl()
        {
            //...
    
            button1.Click += (o, e) => OnButtonClicked(new MyEventArgs(textBox1.Text));
        }
    
        protected virtual void OnButtonClicked(MyEventArgs args)
        {
            var hand = ButtonClicked;
            if(hand != null) ButtonClicked(this, args);
        }
    }
