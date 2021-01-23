    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace Calculator
    {
    	public partial class ComponentMover : Form
    	{
    		private Control trackedControl;
    		private int gridWidth = 100, gridHeight = 20;
    		private int row;
    
    		public ComponentMover()
    		{
    			this.InitializeComponent();
    			this.InitializeDynamic();
    		}
    
    		void draggable_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    		{
    			if (this.trackedControl == null)
    				this.trackedControl = (Control)sender;
    		}
    
    		void draggable_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
    		{
    			if (this.trackedControl != null)
    			{
    				int x = e.X + this.trackedControl.Location.X;
    				int y = e.Y + this.trackedControl.Location.Y;
    				Point moved = new Point(x - x % this.gridWidth, y - y % this.gridHeight);
    
    				Console.WriteLine(e.X + ", " + e.Y + ", " + ", " + moved.X + ", " + moved.Y);
    				if (moved != this.trackedControl.Location)
    					this.trackedControl.Location = moved;
    			}
    		}
    
    		void draggable_MouseUp(object sender, MouseEventArgs e)
    		{
    			this.trackedControl = null;
    		}
    
    		private void AddDragListeners(Control draggable)
    		{
    			draggable.MouseDown += new MouseEventHandler(draggable_MouseDown);
    			draggable.MouseMove += new MouseEventHandler(draggable_MouseMove);
    			draggable.MouseUp += new MouseEventHandler(draggable_MouseUp);
    		}
    	}
    }
