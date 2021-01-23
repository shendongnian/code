    using System;
    using System.Windows.Forms;
    
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form form = new Form
            {
                Controls =
                {
                    new TabControl
                    {
                        Dock = DockStyle.Fill,
                        Name = "TabControl1",
                        TabPages =
                        {
                            new TabPage { Name = "Page1", Text = "Page 1", Controls = { new UserControl { } } },
                            new TabPage { Name = "Page2", Text = "Page 2", Controls = { new UserControl { } } },
                        },
                    },
                },
            };
    
            // Hookup the TabPage so that when it's UserControl's Text property changes, its own Text property is changed to match
            // Now you can simply alter the UserControl's Text property to cause the TabPage to change
            foreach (TabPage page in ((TabControl)form.Controls["TabControl1"]).TabPages)
                page.Controls[0].TextChanged += (s, e) => { Control c = (Control)s; c.Parent.Text = c.Text; };
    
            // Demonstrate that when we change the UserControl's Text property, the TabPage changes too
            foreach (TabPage page in ((TabControl)form.Controls["TabControl1"]).TabPages)
                page.Controls[0].Text = "stackoverflow.com";
    
            Application.Run(form);
        }
    }
