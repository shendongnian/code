       public partial class Form1 : Form {
                public Form1()
                {
                    InitializeComponent();
                    magRadioBox.Checked = true;
                    PropertyGrid propertyGrid1 = new PropertyGrid();
                    propertyGrid1.CommandsVisibleIfAvailable = true;
                    propertyGrid1.Text = "Graph and Plotting Options";
                    propertyGrid1.PropertyValueChanged += propertyGrid1_PropertyValueChanged;
            
                    this.Controls.Add(propertyGrid1);
                } private void Form1_Load(object sender, EventArgs e) { this.Text = "MY Plot Program"; propertyGrid1.SelectedObject = chart1;  }
            
            private void button1_Click(object sender, EventArgs e)  {//some code that is populating my chart(chart1) with data   .... //chart1 being filled with data   }
            
            private void propertyGrid1_PropertyValueChanged(object s , PropertyValueChangedEventArgs e) { 
    myChart.Invalidate();  
    }
