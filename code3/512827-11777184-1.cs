    public class PopoutControl : XtraUserControl
    {
        public void Popout()
        {
            XtraForm PopoutForm = new XtraForm();
            PopoutForm.Controls.Add(this.Clone());
            Dock = DockStyle.Fill;
            PopoutForm.Show();
        }
        
        public PopoutControl Clone()
        { 
           var p = new PopoutControl();
           // implement copying of the current state to p here
           // ...
           return p;
        }
    }
