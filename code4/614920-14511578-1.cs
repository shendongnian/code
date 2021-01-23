    namespace WindowsFormsApplication1
    {
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.IO;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            System.Drawing.Printing.PrintDocument doc = new System.Drawing.Printing.PrintDocument();
            PrintPreviewDialog dlg = new PrintPreviewDialog();
            dlg.Document = doc;
            doc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintPage);
            dlg.ShowDialog();
        }
        private void PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                string fileName = @"C:\Users\brmoore\Desktop\New Text Document.txt";
                StreamReader sr = new StreamReader(fileName);
                string thisIsATest = sr.ReadToEnd();
                sr.Close();
                System.Drawing.Font printFont = new System.Drawing.Font("Arial", 14);
                e.Graphics.DrawString(thisIsATest, printFont, Brushes.Black, 100, 100);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }
    }
}
