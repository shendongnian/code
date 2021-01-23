    using System;
    using System.Collections.Generic; 
    using System.ComponentModel; 
    using System.Data; 
    using System.Linq; 
    using System.Text;
    using System.Windows.Forms;
    using iTextSharp.text; 
    using iTextSharp.text.pdf;
    
    namespace pdfreared { public partial class Form1 : Form { public Form1() { InitializeComponent(); }
    
        private void button1_Click(object sender, EventArgs e)
        {
            PdfReader reader = new PdfReader(@"D:\Files Formats\Icon.ai");
            int n = reader.NumberOfPages;
            label4.Text = n.ToString();
    
            // size of the first page
            Rectangle psize = reader.GetPageSize(1);
            float width = psize.Width;
            label1.Text ="Width= " + Convert.ToString(width);
            float height = psize.Height;
            label2.Text = "Height = " + Convert.ToString(height);
          //  reader.Metadata.
    
            Console.WriteLine("Size of page 1 of {0} => {1} × {2}", n, width, height);
            // file properties
            Dictionary<string, string> infodict = reader.Info;
            foreach (KeyValuePair<string, string> kvp in infodict)
            {
                Console.WriteLine(kvp.Key + " => " + kvp.Value);
                label3.Text = kvp.Key + " => " + kvp.Value;
    
    
            }
    
        }
    }
