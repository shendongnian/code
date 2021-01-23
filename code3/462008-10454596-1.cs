    using System;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    
    class Form1 : Form
    {
        class CompanyInfo
        {
            public string Name { get; set; }
        }
    
        static string RemoveTrailingDash(string value)
        {
            int dashIndex = value.LastIndexOf('-');
            if (dashIndex > 0)
                return value.Substring(0, dashIndex).TrimEnd();
            return value;
        }
    
        public Form1()
        {
            var companies = new CompanyInfo[]
            {
                new CompanyInfo { Name = "Ajax - 1200" },
                new CompanyInfo { Name = "Bermuda Corp - 1" },
                new CompanyInfo { Name = "Capitol Inc" },
                new CompanyInfo { Name = "Dash LLC - " },
            };
    
            Controls.Add(new ComboBox
            {
                Location = new Point(10, 10),
                DropDownStyle = ComboBoxStyle.DropDownList,
    
                DataSource = companies.Select(c => new { FormattedName = RemoveTrailingDash(c.Name) }).ToList(),
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
