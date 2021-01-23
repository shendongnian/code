    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Drawing.Drawing2D;
    
        namespace WindowsFormsApplication2
        {
            public partial class Form1 : Form
            {
                public Form1()
                {
                    InitializeComponent();
                }
        
                private void Form1_Load(object sender, EventArgs e)
                {
                    GraphicsPath pathPolygon = new GraphicsPath(FillMode.Winding);
                    GraphicsPath pathEllipse = new GraphicsPath(FillMode.Winding);
        
        
                    //------ POLYGON (X)
                    Point[] points = new Point[12];
                    points[0].X = 5;
                    points[0].Y = 15;
                    points[1].X = 10;
                    points[1].Y = 10;
                    points[2].X = 18;
                    points[2].Y = 18;
                    points[3].X = 26;
                    points[3].Y = 10;
                    points[4].X = 31;
                    points[4].Y = 15;
                    points[5].X = 23;
                    points[5].Y = 23;
                    points[6].X = 31;
                    points[6].Y = 31;
                    points[7].X = 26;
                    points[7].Y = 36;
                    points[8].X = 18;
                    points[8].Y = 28;
                    points[9].X = 10;
                    points[9].Y = 36;
                    points[10].X = 5;
                    points[10].Y = 31;
                    points[11].X = 13;
                    points[11].Y = 23;
        
                    Point maxVals = new Point(31, 36);
        
                    pathPolygon.AddPolygon(points);
        
                    Region region = new Region(pathPolygon);
        
                    button1.BackColor = Color.Red;
                    button1.FlatAppearance.BorderSize = 0;
                    button1.FlatStyle = FlatStyle.Flat;
                    button1.Region = region;
                    button1.SetBounds(button1.Location.X, button1.Location.Y, maxVals.X, maxVals.Y);
                    
                    Rectangle ellipse = new Rectangle(0, 0, 100, 50);
                    maxVals = new Point(100, 50);
                    pathEllipse.AddEllipse(ellipse);
                    region = new Region(pathEllipse);
        
                    button2.BackColor = Color.Red;
                    button2.FlatAppearance.BorderSize = 0;
                    button2.FlatStyle = FlatStyle.Flat;
                    button2.Region = region;
                    button2.SetBounds(button2.Location.X, button2.Location.Y, maxVals.X, maxVals.Y);
                    
                }
            }
        }
