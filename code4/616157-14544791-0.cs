    public class FirstUserControl:UserControl
    {
        Public event EventHandler MyEvent;
        //Public property in your first usercontrol
        public string MyText
        {
            get{return this.textbox1.Text;} //textbox1 is the name of your textbox
        }
        private void MyButton_Clicked(/* args */)
        {
            if (MyEvent!=null)
            {
                MyEvent(null, null);
            }
        }
        //other codes
    }
    public class SecondUserControl:UserControl
    {
        //Public property in your first usercontrol
        public string MyText
        {
            set{this.label1.Text = value;} //label1 is the name of your label
        }
        //other codes
    }
