    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Shapes;
    using System.Windows.Media;
    public class Form1
    {
	//make a new TreeCanvas
	private TreeCanvas MyTreeCanvas = new TreeCanvas();
	public Form1()
	{
		InitializeComponent();
		//attach the TreeCanvas component to the element host
		ElementHost1.Child = MyTreeCanvas;
		ElementHost1.Height = 300;
		ElementHost1.Width = 300;
		// Just adding some random stuff to the treeview
		int i = 0;
		int j = 0;
		for (i = 0; i <= 10; i++) {
			TreeViewItem nitm = new TreeViewItem();
			nitm.Header = "Item " + Convert.ToString(i);
			MyTreeCanvas.TreeView1.Items.Add(nitm);
			for (j = 1; j <= 3; j++) {
				TreeViewItem itm = (TreeViewItem)MyTreeCanvas.TreeView1.Items(i);
				itm.Items.Add("Item " + Convert.ToString(j));
			}
		}
		//Draw a line on the canvas with the treeview
		Line myLine = new Line();
		myLine.Stroke = Brushes.Red;
		myLine.X1 = 1;
		myLine.X2 = 150;
		myLine.Y1 = 1;
		myLine.Y2 = 150;
		myLine.HorizontalAlignment = HorizontalAlignment.Left;
		myLine.VerticalAlignment = VerticalAlignment.Center;
		myLine.StrokeThickness = 2;
		MyTreeCanvas.Canvas1.Children.Add(myLine);
     }
     }
