    public partial class Form1 : Form
    {
        ContextMenuStrip cms = new ContextMenuStrip();
        
        public Form1()
        {
            InitializeComponent();
            //cms.Items[;
        }
        public ToolStripItemCollection ConItems
        {
            get
            {
                return cms.Items;
            }
            set
            {
                cms.Items.Clear();
                ToolStripItemCollection tsc=(ToolStripItemCollection)value;
                foreach (ToolStripItem tsi in tsc)
                {
                    cms.Items.Add(tsi);
                }
            }
        }
    
    }
