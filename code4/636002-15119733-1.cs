    namespace FFT_Plotter
    { 
        [DefaultPropertyAttribute("Text")]// This is where the initial position of the grid is set 
        public class MyChart : Chart 
        {
            public event EventHandler PropertyChanged;
    private void OnPropertyChanged(object sender, EventArgs e)
    {
    EventHandler eh = propertyChanged;
    if(eh !=null)
    {
    eh(sender, e);
    }
            [BrowsableAttribute(false)]
            public new System.Drawing.Color BackColor
            {
                get { return BackColor; }//Here back color is just an example of a property, not necessarily one that I would make non-Browsable
                set { 
    base.BackColor = value; 
    OnPropertyChanged(this,EventArgs.Empty);
    }
            }
        }
    }
