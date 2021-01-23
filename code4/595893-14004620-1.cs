    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1(){
                InitializeComponent();
            }
                  
            private int counter = 0;
            private int px = 10;
            private int py = 180;
            private int total5Clicks = 0;
    
            private void button1_Click(object sender, EventArgs e)
            {
                counter++;
                label1.Text = "Total Clicks = " + counter.ToString();
                if (Math.Abs(counter % 5) == 0){
                    if (Math.Abs(counter / 5) > 0){
                        total5Clicks = total5Clicks + 1;
                        PaintOnChartPanel(total5Clicks);}
                 }
             }
            
          private void panel1_Paint(object sender, PaintEventArgs e){           
          }
    
          private void PaintOnChartPanel(int total5Times)
          {            
            //Add a new Panel Paint EventHandler
            panel1.Paint += new PaintEventHandler(panel1_Paint);
    
            using (Graphics g = this.panel1.CreateGraphics())
            {
                Brush brush = new SolidBrush(Color.Green);
                g.FillRectangle(brush, px, py, 20, 20);                           
                Pen pen = new Pen(new SolidBrush(Color.White));
                g.DrawRectangle(pen, px, py, 20, 20);                    
                        
                //add each total5Click into chart block
                g.DrawString((total5Times).ToString(), new Font("Arial", 7), 
                new SolidBrush(Color.AntiqueWhite),
                px + 1, py+8, StringFormat.GenericDefault);
                pen.Dispose();}
    
                if (py > 20){
                    py = py - 20;}
                else{
                    MessageBox.Show("Reached Top of the Panel");
                    if (px < 200){
                        px = px + 20;
                        py = 180;}
                    else{
                        MessageBox.Show("Reached Right of the Panel");
                    }
                }
            }
        }
    }
