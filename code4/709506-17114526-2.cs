    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private readonly Stack<int> _stack = new Stack<int>();
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
            {
                // Column history
                _stack.Push(e.ColumnIndex);
    
                // Number of columns to track
                int columns = 3;
                // Build sort string
                int[] array = _stack.Distinct().ToArray();
                var builder = new StringBuilder();
                for (int index = 0; index < array.Length; index++)
                {
                    int i = array[index];
                    if (index >= columns)
                    {
                        break;
                    }
    
                    DataGridViewColumn gridViewColumn = dataGridView1.Columns[i];
                    string sort = null;
                    switch (gridViewColumn.HeaderCell.SortGlyphDirection)
                    {
                        case SortOrder.None:
                        case SortOrder.Ascending:
                            sort = "ASC";
                            break;
                        case SortOrder.Descending:
                            sort = "DESC";
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    builder.AppendFormat("{0} {1}, ", gridViewColumn.Name, sort);
                }
                string s = builder.ToString();
                s = s.Remove(s.Length - 2);
                Console.WriteLine(s);
            }
        }
    }
