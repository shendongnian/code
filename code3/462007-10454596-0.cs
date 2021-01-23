    using System;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    
    class Form1 : Form
    {
        public Form1()
        {
            Controls.Add(new ComboBox
            {
                Location = new Point(10, 10),
                DropDownStyle = ComboBoxStyle.DropDownList,
    
                DataSource = Enumerable.Range(0, 10).Select(c => new { FormattedName = String.Format("Item #{0}", c) }).ToList(),
                DisplayMember = "FormattedName",
            });
        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
