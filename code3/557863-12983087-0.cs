    namespace HomeInventory2
    {
        public partial class Form1 : Form
        {
    
            public Form1(IEnumerable<string> prepopulated)
            {
                InitializeComponent();
                IEnumerable<String> lines = prepopulated;
                textBoxAmount.Text = lines.ElementAtOrDefault(0);
                textBoxCategories.Text = lines.ElementAtOrDefault(1);
                textBoxProperties.Text = lines.ElementAtOrDefault(2);
                textBoxValue.Text = lines.ElementAtOrDefault(3);
            }
            public Form1()
            {
                InitializeComponent();
                IEnumerable<String> lines = null;
                textBoxAmount.Text = lines.ElementAtOrDefault(0);
                textBoxCategories.Text = lines.ElementAtOrDefault(1);
                textBoxProperties.Text = lines.ElementAtOrDefault(2);
                textBoxValue.Text = lines.ElementAtOrDefault(3);
            }
    
            private void label1_Click(object sender, EventArgs e)
            {
    
            }
    
            private void submitButton_Click(object sender, EventArgs e)
            {
                CreateInventory create = new CreateInventory();
                create.ItemAmount = textBoxAmount.Text;
                create.ItemCategory = textBoxCategories.Text;
                create.ItemProperties = textBoxValue.Text;
                create.ItemValue = textBoxValue.Text;
    
                InventoryMngr invtryMngr = new InventoryMngr();
                invtryMngr.Create(create);
    
            }
        }
    }
