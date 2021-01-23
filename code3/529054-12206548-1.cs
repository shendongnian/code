    using System;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    class Item
    {
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
    }
    
    class Form1 : Form
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    
        DataGridView dataGridViewPlatypus;
    
        public Form1()
        {
            ClientSize = new Size(480, 260);
            Controls.Add(dataGridViewPlatypus = new DataGridView
            {
                Dock = DockStyle.Fill,
                DataSource = Enumerable.Range(1, 10).Select(i => new Item { A = "", B = "", C = "", D = "" }).ToList(),
            });
        }
    
        [DllImport("User32.dll")]
        extern static int PostMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
    
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (msg.Msg == 256) // WM_KEYDOWN
            {
                if (this.ActiveControl == dataGridViewPlatypus.EditingControl)
                {
                    var currentCell = dataGridViewPlatypus.CurrentCell;
                    if (currentCell.OwningColumn is DataGridViewTextBoxColumn && dataGridViewPlatypus.EditingControl.Text.Length > 0)
                    {
                        int rowIndex = currentCell.RowIndex;
                        int columnIndex = currentCell.ColumnIndex;
    
                        if (++columnIndex >= dataGridViewPlatypus.Columns.Count)
                        {
                            columnIndex = 0;
                            if (++rowIndex >= dataGridViewPlatypus.Rows.Count)
                                rowIndex = 0;
                        }
    
                        dataGridViewPlatypus.CurrentCell = dataGridViewPlatypus[columnIndex, rowIndex];
                        PostMessage(dataGridViewPlatypus.Handle, msg.Msg, msg.WParam, msg.LParam);
                        return true; // Don't process this message, we re-sent it to the DGV
                    }
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
