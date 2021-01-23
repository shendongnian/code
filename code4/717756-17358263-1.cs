    public partial class Form1 : Form
    {
        List<string> availableCarColors = new List<string>();
        List<MyCar> data = new List<MyCar>();
        public Form1()
        {
            InitializeComponent();
            availableCarColors.Add("Red");
            availableCarColors.Add("Blue");
            data.Add(new MyCar("Lexus", "Blue"));
            data.Add(new MyCar("BMW", "Red"));
            DataGridViewTextBoxColumn colModel = new DataGridViewTextBoxColumn();
            colModel.Name = "Model";                //Header Text
            colModel.DataPropertyName = "Model";    //Property Name of my car class
            
            DataGridViewComboBoxColumn colColor = new DataGridViewComboBoxColumn();
            colColor.Name = "Color";
            colColor.DataPropertyName = "Color";
            colColor.DataSource = availableCarColors;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] {colModel, colColor});
            dataGridView1.DataSource = data;
        }
        class MyCar
        {
            public string Model { get; set; }
            public string Color { get; set; }
            public MyCar(string model, string color)
            {
                Model = model;
                Color = color;
            }
        }
    }
