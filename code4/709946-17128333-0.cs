        using System;
        using System.Media;
        using System.Windows.Forms;
        
        namespace WindowsFormsApplication1
        {
            public partial class Form1 : Form
            {
                public Form1()
                {
                    InitializeComponent();
                }
        
                private void btPlay_Click(object sender, EventArgs e)
                {
                    string path;
                    using (var dlg = new OpenFileDialog())
                    {
                        dlg.Multiselect = false;
                        dlg.Filter = "WAV files|*.wav";
                        if (dlg.ShowDialog() == DialogResult.Cancel) return;
                        path = dlg.FileName;
                    }
                    SoundPlayer sp = new SoundPlayer(path);
                    sp.Play();
                }  
            }
        }
