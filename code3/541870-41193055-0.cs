    using System.Windows.Forms;
    public class EnhancedNUD : NumericUpDown
    {
        public event EventHandler BeforeUpButtoning;
        public event EventHandler BeforeDownButtoning;
        public event EventHandler AfterUpButtoning;
        public event EventHandler AfterDownButtoning;
        public override void UpButton()
        {
            if (BeforeUpButtoning != null) BeforeUpButtoning.Invoke(this, new EventArgs());
            //Do what you want here...
            //Or comment out the line below and do your own thing
            base.UpButton();
            if (AfterUpButtoning != null) AfterUpButtoning.Invoke(this, new EventArgs());
        }
        public override void DownButton()
        {
            if (BeforeDownButtoning != null) BeforeDownButtoning.Invoke(this, new EventArgs());
            //Do what you want here...
            //Or comment out the line below and do your own thing
            base.DownButton();
            if (AfterDownButtoning != null) AfterDownButtoning.Invoke(this, new EventArgs());
        }
    }
