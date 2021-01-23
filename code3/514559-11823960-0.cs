    public partial class CustomButton  : Button {
        public override string Text
        {
            get
            {
                //return custom text
                return base.Text;
            }
            set
            {
                //modify value to suit your needs
                base.Text = value;
            }
        }
     }
