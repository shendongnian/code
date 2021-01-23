    using System;
    using System.IO;
    using System.Windows.Forms;
    namespace DynamicToolStrip
    {
        static class Program
        {
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new DynamicToolStripForm());
            }
            class DynamicToolStripForm : Form
            {
                ToolStrip m_toolstrip = new ToolStrip();
                public DynamicToolStripForm()
                {
                    Controls.Add(m_toolstrip);
                    AddToolStripButtons();
                }
                void AddToolStripButtons()
                {
                    const int iMAX_FILES = 5;
                    string[] astrFiles = Directory.GetFiles(@"C:\");
                    for (int i = 0; i < iMAX_FILES; i++)
                    {
                        string strFile = astrFiles[i];
                        ToolStripButton tsb = new ToolStripButton();
                        tsb.Text = Path.GetFileName(strFile);
                        tsb.Tag = strFile;
                        tsb.Click += new EventHandler(tsb_Click);
                        m_toolstrip.Items.Add(tsb);
                    }
                }
                void tsb_Click(object sender, EventArgs e)
                {
                    ToolStripButton tsb = sender as ToolStripButton;
                    if (tsb != null && tsb.Tag != null)
                        MessageBox.Show(String.Format("Hello im the {0} button", tsb.Tag.ToString()));
                }
            }
        }
    }
