    public ExampleForm()
        {
            InitializeComponent();
            datagridWorkorderItems.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn qtyColumn = new DataGridViewTextBoxColumn();
            qtyColumn.DataPropertyName = "Qty";
            qtyColumn.HeaderText = "Qty";
            datagridWorkorderItems.Columns.Add(qtyColumn);
            DataGridViewComboBoxColumn partColumn = new DataGridViewComboBoxColumn();
            partColumn.Items.Add(new Part() { ID = 0, PartName = "Tire" });
            partColumn.Items.Add(new Part() { ID = 1, PartName = "Motor" });
            partColumn.HeaderText = "Part";
            partColumn.DataPropertyName = "PartID";
            partColumn.ValueMember = "ID";
            partColumn.DisplayMember = "PartName";
            datagridWorkorderItems.Columns.Add(partColumn);
            List<WorkOrder> workOrders = new List<WorkOrder>();
            workOrders.Add(new WorkOrder() { Qty = 0, PartID = 0});
            workOrders.Add(new WorkOrder() { Qty = 2, PartID = 1});
            datagridWorkorderItems.DataSource = workOrders;
        }
    }
    public class WorkOrder
    {
        public int Qty { get; set; }
        public int PartID { get; set; }
    }
    public class Part
    {
        public int ID { get; set; }
        public string PartName { get; set; }
    }
