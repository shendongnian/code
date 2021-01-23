    using System;
    using System.Linq;
    using System.Windows.Forms;
    
    class MainForm : Form
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    
        public MainForm()
        {
            string[] comboSource = Enumerable.Range(1, 30).Select(i => String.Format("Item #{0}", i)).ToArray();
    
            Controls.Add(new DataGridView
            {
                AutoGenerateColumns = false,
                Columns = { new DataGridViewComboBoxColumn { HeaderText = "Item", DataSource = comboSource }, },
                DataSource = comboSource, // just adding dummy items for effect
                Dock = DockStyle.Fill,
            });
        }
    }
