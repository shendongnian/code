    using System;
    using System.IO; //added
    using System.Windows.Forms;
    using System.Runtime.Serialization.Formatters.Binary; //added
    
    //added
    namespace testowa // this my name of project
    {
    
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            
    
            [Serializable] // It allow our class to be saved in file
            public class data // Our class for data
            {
                public string name;
                public string surname;
                public string city;
                public string number;
    
            }
    
    
    
            private void saveToolStripMenuItem_Click(object sender, EventArgs e)
            {
                GRID.EndEdit();
                SaveFileDialog saveFileDialog1 = new SaveFileDialog(); //Creating a file save dialog 
    
                saveFileDialog1.RestoreDirectory = true;
                //read and filter the raw data
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    FileStream output = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    ;
                    int n = GRID.RowCount;
                    data[] Person = new data[n - 1]; //We have as many records as many rows, rows are added automaticly so we have always one row more than we need, so n is a number of rows -1 empty row
                    for (int i = 0; i < n - 1; i++)
                    {
    
                        Person[i] = new data();
                        //GRID has two numbers in"[]" first numer is an index of column, second is a an idnex of row', indexing always starts from 0'
                        Person[i].name = GRID[0, i].Value.ToString();
                        Person[i].surname = GRID[1, i].Value.ToString();
                        Person[i].city = GRID[2, i].Value.ToString();
                        Person[i].number = GRID[3, i].Value.ToString();
    
                    }
    
                    formatter.Serialize(output, Person);
    
                    output.Close();
                }
    
            }
    
            private void openToolStripMenuItem_Click(object sender, EventArgs e) // Reading a File and adding data to GRID
            {
                openFileDialog1 = new OpenFileDialog();
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    BinaryFormatter reader = new BinaryFormatter();
                    FileStream input = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                    data[] Person = (data[])reader.Deserialize(input);
                    GRID.Rows.Clear();
                    for (int i = 0; i < Person.Length; i++)
                    {
                        GRID.Rows.Add();
                        GRID[0, i].Value = Person[i].name;
                        GRID[1, i].Value = Person[i].surname;
                        GRID[2, i].Value = Person[i].city;
                        GRID[3, i].Value = Person[i].number;
    
                    }
    
                }
            }
    
    
    
            private void closeToolStripMenuItem_Click(object sender, EventArgs e)
            {
                Close(); // closing an app
            }
    
            void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
            {
                
            }
    
            void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                
            }
        }
    }
