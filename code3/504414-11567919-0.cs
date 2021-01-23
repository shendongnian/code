    using System;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    
    class Form1 : Form
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    
        public Form1()
        {
            ClientSize = new Size(640, 480);
            DataGridView dgv = new DataGridView
                {
                    Dock = DockStyle.Fill,
                    Font = new Font(FontFamily.GenericSansSerif, 36),
                    AutoGenerateColumns = false,
                    AllowUserToAddRows = false,
                    RowHeadersVisible = false,
                    ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                    Columns =
                    {
                        new DataGridViewTextBoxColumn { HeaderText = "TextBox", DataPropertyName = "Text", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, },
                        new DataGridViewButtonColumn { Name = "ButtonColumn", HeaderText = "Button", AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader, DefaultCellStyle = new DataGridViewCellStyle { Padding = new Padding(2) } },
                    },
                    DataSource = Enumerable.Range(1, 5).Select(i => new { Text = "Item " + i.ToString() }).ToList(),
                };
            
            dgv.RowHeightChanged += (s, e) =>
                {
                    DataGridViewCell cell = e.Row.Cells["ButtonColumn"];
                    int pad = (e.Row.Height - 25) / 2;
                    cell.Style.Padding = new Padding(2, pad, 2, pad);
                };
    
            Controls.Add(dgv);
        }
    }
