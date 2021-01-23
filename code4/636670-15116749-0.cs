    [DefaultPropertyAttribute("Text")]
    public class MyChart : Chart 
    {
        public event EventHandler PropertyChanged;
        private void OnPropertyChanged(object sender, EventArgs e)
        {
            if(PropertyChanged !=null)
            {
                PropertyChanged(sender, e);
            }
        }
        [BrowsableAttribute(false)]
        public new string Text { get; set; }
        [BrowsableAttribute(true)]
        public new System.Drawing.Color BackColor
        {
            get { return base.BackColor; }//Here back color is just an example of a property, not necessarily one that I would make non-Browsable
            set 
            { 
                base.BackColor = value; 
                OnPropertyChanged(this,EventArgs.Empty);
            }    
        }     
    }
