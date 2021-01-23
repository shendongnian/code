    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication20 {
        public partial class Form1 : Form {
            public Form1() {
                InitializeComponent();
            }
            //Used for our sample data
            public class Person {
                public string FirstName { get; set; }
                public string LastName { get; set; }
            }
    
            private void Form1_Load(object sender, EventArgs e) {
                //Sample image, set to a PNG
                var sampleImagePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "sample.png");
                //Full path to the PDF to export
                var exportFilePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Test.pdf");
    
                //Next we're going to create all of the basic controls per the OP's scenario
    
                //Create some sample data to put into our DGV
                var P1 = new Person() { FirstName = "Alice", LastName = "Cooper" };
                var P2 = new Person() { FirstName = "Bob", LastName = "Dole" };
                var People = new List<Person>(new Person[] { P1, P2 });
    
                //Create our sample DataGridView
                var dataGridView1 = new DataGridView();
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = People;
                dataGridView1.Location = new Point(0, 0);
    
                //Create our sample PictureBox
                var PB = new PictureBox();
                PB.Load(sampleImagePath);
                PB.Location = new Point(400, 0);
                PB.SizeMode = PictureBoxSizeMode.AutoSize;
    
    
                //Create our sample panel and give it room to show everything
                var panel = new Panel();
                panel.AutoSize = true;
                panel.Dock = DockStyle.Fill;
    
                //Add the above controls to our DGV
                panel.Controls.Add(dataGridView1);
                panel.Controls.Add(PB);
                //Add the DGV to the form
                this.Controls.Add(panel);
    
                //Basic PDF creation here, nothing special
                using (var fs = new FileStream(exportFilePath, FileMode.Create, FileAccess.Write, FileShare.None)) {
                    using (var pdfDoc = new Document(PageSize.A4)) {
                        using (var writer = PdfWriter.GetInstance(pdfDoc, fs)) {
                            pdfDoc.Open();
    
                            //Get our image (Code is mostly the OP's)
                            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(PB.Image, System.Drawing.Imaging.ImageFormat.Png);
                            jpg.ScaleToFit(750, 850);
                            jpg.SetAbsolutePosition(0, 0);
    
                            //Create our table
                            var table = new PdfPTable(dataGridView1.Columns.Count);
    
                            //Add the headers from the DGV to the table
                            for (int j = 0; j < dataGridView1.Columns.Count; j++) {
                                table.AddCell(new Phrase(dataGridView1.Columns[j].HeaderText));
                            }
    
                            //Flag the first row as a header
                            table.HeaderRows = 1;
    
                            //Add the actual rows from the DGV to the table
                            for (int i = 0; i < dataGridView1.Rows.Count; i++) {
                                for (int j = 0; j < dataGridView1.Columns.Count; j++) {
                                    table.AddCell(new Phrase(dataGridView1[j, i].Value.ToString()));
                                }
                            }
    
                            //Add our image
                            pdfDoc.Add(jpg);
                            //Add out table
                            pdfDoc.Add(table);
                            pdfDoc.Close();
                        }
                    }
                }
            }
        }
    }
