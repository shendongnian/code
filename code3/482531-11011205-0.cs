    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public class  Books
        {
            public string Title { get; set; }
            public int TotalRating { get; set; }
        }
    
        public partial class Form2 : Form
        {
            public Form2()
            {
                var list = new List<Books>
                               {
                                   new Books() {Title = "Harry Potter", TotalRating = 5},
                                   new Books() {Title = "C#", TotalRating = 5}
                               };
                InitializeComponent();
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = list;
            }
    
        }
    }
