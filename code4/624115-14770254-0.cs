    MyClass.NotifyParentUI += new EventHandler<MyArgs>(UpdateMyLabel);
     public void UpdateMyLabel(object sender, MyArgs ea)
        {
            this.Invoke(new MethodInvoker(
                delegate()
                {
                    myLabel.Text = ea.Message;
                }));
        }
    
    public class MyArgs : EventArgs
    {
        public string Message { get; set; }
    }
