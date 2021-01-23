    namespace Stackoverflow.Hannish.SaveLayout
    {
        using System;
        using System.Collections.Generic;
        using System.IO;
        using System.Text;
        using System.Windows.Forms;
    
        public partial class Form1 : Form
        {
            /// <summary>
            /// Here we store the layout data as a string. This is the data, that
            /// gets saved to disk / database / etc.
            /// </summary>
            private string layoutdata = string.Empty;
    
            public Form1()
            {
                this.InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                // Just some FooBar data.
                var data = new List<DataValue>
                               {
                                   new DataValue { Id = 1, Name = "Xyz", IsCool = true }, 
                                   new DataValue { Id = 2, Name = "Abc", IsCool = false }
                               };
    
                this.gridControl1.DataSource = data;
            }
    
            private void bnLoadLayout_Click(object sender, EventArgs e)
            {
                using (var stream = new MemoryStream())
                {
                    var strdata = Encoding.Default.GetBytes(this.layoutdata);
                    stream.Write(strdata, 0, strdata.Length);
                    stream.Seek(0, SeekOrigin.Begin);
                    this.gridView1.RestoreLayoutFromStream(stream);
                }
            }
    
            private void bnSaveLayout_Click(object sender, EventArgs e)
            {
                using (var stream = new MemoryStream())
                {
                    this.gridView1.SaveLayoutToStream(stream);
                    this.layoutdata = Encoding.Default.GetString(stream.ToArray());
                }
            }
        }
    }
