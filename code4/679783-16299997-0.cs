    public partial class MapForm : Form
        {
            Map mapData = new Map();
            public CheckBox xVehicles; //Like here
    
            public MapForm()
            {
                InitializeComponent();
                <..snip...>
            }
    
            <...snip...>
    
            private void chkVehicles_CheckedChanged(object sender, EventArgs e)
            {
                xVehicles = (CheckBox)sender; //assign it the sender
            }
     //.....your rest of the code
