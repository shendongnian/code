    public partial class Form1 : Form
    {
        
        private BindingSource cars;
        private BindingSource masterColors;
        public Form1()
        {
            InitializeComponent();
            masterColors = new BindingSource();
            masterColors.Add(new CarColor{Name = "Blue", Index = 1});
            masterColors.Add(new CarColor{Name = "Red", Index = 2});
            masterColors.Add(new CarColor { Name = "Green", Index = 3 });
            masterColors.Add(new CarColor { Name = "White", Index = 4 });
            BindingList<CarColor> fordColors = new BindingList<CarColor>();
            fordColors.Add(new CarColor{Name = "Blue", Index = 1});
            fordColors.Add(new CarColor{Name = "Red", Index = 2});
            BindingList<CarColor> toyotaColors = new BindingList<CarColor>();
            toyotaColors.Add(new CarColor { Name = "Green", Index = 3 });
            toyotaColors.Add(new CarColor { Name = "White", Index = 4 });
            cars = new BindingSource();
            cars.Add(new Car { Make = "Ford", SelectedColorIndex = 1, AllColors = fordColors });
            cars.Add(new Car { Make = "Toyota", SelectedColorIndex = 3, AllColors = toyotaColors });
            dataGridView1.DataSource = cars;
            dataGridView1.Columns["SelectedColorIndex"].Visible = false;
            //dataGridView1.Columns["AllColors"].Visible = false;
            DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
            col.Name = "AvailableColors";
            col.DataSource = masterColors;
            col.DisplayMember = "Name";
            col.DataPropertyName = "SelectedColorIndex";
            col.ValueMember = "Index";
            dataGridView1.Columns.Add(col);
            dataGridView1.CellBeginEdit += new DataGridViewCellCancelEventHandler(dataGridView1_CellBeginEdit);
            dataGridView1.CellEndEdit += new DataGridViewCellEventHandler(dataGridView1_CellEndEdit);
            dataGridView1.DefaultValuesNeeded += new DataGridViewRowEventHandler(dataGridView1_DefaultValuesNeeded);
        }
        void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["AvailableColors"].Index)
            {
                if (e.RowIndex != dataGridView1.NewRowIndex)
                {
                    // Set the combobox cell datasource to the filtered BindingSource
                    DataGridViewComboBoxCell dgcb = (DataGridViewComboBoxCell)dataGridView1
                                    [e.ColumnIndex, e.RowIndex];
                    Car rowCar = dataGridView1.Rows[e.RowIndex].DataBoundItem as Car;
                    dgcb.DataSource = rowCar.AllColors;
                }
            }
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["AvailableColors"].Index)
            {
                // Reset combobox cell to the unfiltered BindingSource
                DataGridViewComboBoxCell dgcb = (DataGridViewComboBoxCell)dataGridView1
                                [e.ColumnIndex, e.RowIndex];
                dgcb.DataSource = masterColors; //unfiltered
            }
        }
        void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["SelectedColorIndex"].Value = 1;
        }
    }
    public class Car
    {
        public String Make { get; set; }
        public BindingList<CarColor> AllColors { get; set; }
        public int SelectedColorIndex { get; set; }
    }
    public class CarColor
    {
        public String Name { get; set; }
        public int Index { get; set; }
    }
