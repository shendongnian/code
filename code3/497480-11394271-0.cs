    public partial class Form1 : Form
    {
        private BindingSource carBindingSource = new BindingSource();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = carBindingSource;
            this.carBindingSource.AddingNew +=
            new AddingNewEventHandler(carBindingSource_AddingNew);
            carBindingSource.AllowNew = true;
        }
        void carBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new Car();
        }
    }
