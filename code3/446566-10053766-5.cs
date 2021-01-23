    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Shapes;
    using System.Windows.Media;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            //make a new TreeCanvas
    
            private TreeCanvas MyTreeCanvas = new TreeCanvas();
    
            public Form1()
            {
                InitializeComponent();
                //attach the TreeCanvas component to the element host
                this.Width = 400;
                this.Height = 400;
                elementHost1.Child = MyTreeCanvas;
                elementHost1.Location = new System.Drawing.Point(30, 30);
                elementHost1.Height = 300;
                elementHost1.Width = 300;
    
                // Just adding some random stuff to the treeview
                int i = 0;
                int j = 0;
                for (i = 0; i <= 10; i++)
                {
                    TreeViewItem nitm = new TreeViewItem();
                    nitm.Header = "Item " + Convert.ToString(i);
                    MyTreeCanvas.TreeView1.Items.Add(nitm);
                    for (j = 1; j <= 3; j++)
                    {
                        TreeViewItem itm = (TreeViewItem)MyTreeCanvas.TreeView1.Items[i];
                        itm.Items.Add("Item " + Convert.ToString(j));
                    }
                }
    
                //Draw a line on the canvas with the treeview
                Line myLine = new Line();
                myLine.Stroke = System.Windows.Media.Brushes.Red;
                myLine.X1 = 1;
                myLine.X2 = 50;
                myLine.Y1 = 1;
                myLine.Y2 = 300;
                myLine.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                myLine.VerticalAlignment = VerticalAlignment.Center;
                myLine.StrokeThickness = 2;
                MyTreeCanvas.Canvas1.Children.Add(myLine);
            }
    
        }
    }
