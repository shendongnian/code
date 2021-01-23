    public partial class Form1 : Form
    {
        private PropertyGrid propertyGrid1;
        public Form1()
        {
            InitializeComponent();
            //propertyGrid1 = new PropertyGrid();
            propertyGrid1.CommandsVisibleIfAvailable = true;
            propertyGrid1.Text = "Graph and Plotting Options";
            propertyGrid1.PropertyValueChanged += propertyGrid1_PropertyValueChanged;
            this.Controls.Add(propertyGrid1);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "MY Plot Program";
            propertyGrid1.SelectedObject = chart1; 
        }
        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            //Calling the method that will refresh my chart1 
            chart1.Invalidate();
        }
    }
 
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
