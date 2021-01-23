    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace EditingCells
    {
        public partial class Form1 : Form
        {
            private readonly CarsEntities _myDataBase = new CarsEntities();
    
            public Form1()
            {
                InitializeComponent();
    
                List<MyCar> myData = _myDataBase.MyCars.ToList();
    
                // Yes, you have do make Columns manually.
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = myData;
    
                List<Color> myColors = _myDataBase.Colors.ToList();
    
                var carOwner = new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Owner",
                        HeaderText = @"Owner",
                        Name = "Owner",
                    };
                dataGridView1.Columns.Add(carOwner);
    
                var carColor = new DataGridViewComboBoxColumn
                    {
                        // Field Name where existing data is stored
                        DataPropertyName = "CarColor",
                        HeaderText = @"Color",
                        Name = "Color",
                        DataSource = myColors,
                        DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
                        AutoComplete = true,
                        
                        // Field value from DataSource to store in Car.Color field
                        ValueMember = "ColorName",
    
                        // Field value from DataSource to show in DataGridView Column
                        DisplayMember = "ColorName",
                    };
                dataGridView1.Columns.Add(carColor);
            }
    
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                _myDataBase.SaveChanges();
            }
        }
    }
