    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            myClass1.sister = myClass2;
            myClass2.sister = myClass1;
        }
    }
    public class myClass : ListView
    {
        //This is where we will store the information about the sister Control
        public Control sister;
        
        public myClass()
        {
        }
        //here is where we override the OnDoubleCLick Event
        protected override void OnDoubleClick(EventArgs e)
        {
            //Make sure this control has a sister 
            if (sister != null)
            {
                //add a temporary storage location for the selected Item
                ListViewItem item = this.SelectedItems[0];
                //Remove the Item from the clicked List
                this.Items.Remove(item);
                //Add the Item to the sister List
                ((myClass)sister).Items.Add(item);
            }
            base.OnDoubleClick(e);
        }
    }
