    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Windows.Forms.VisualStyles;
    
    namespace WindowAutoAdapt
    {
    	public partial class Form1: Form
    	{
    		private int AllButtonsAndPadding = 10;//seems things are coming up about this amount short so.  . .
    		private VisualStyleRenderer renderer = null;
    		private int minWidth = 0;//will hold either the minimum size width if specified or the design time width of the form.
    
    		public Form1()
    		{
    			InitializeComponent();
    
    			//Capture an explicit minimum width if present else store the design time width.
    			if (this.MinimumSize.Width > 0)
    			{
    				minWidth = this.MinimumSize.Width;//use an explicit minimum width if present.
    			}
    			else
    			{
    				minWidth = this.Size.Width;//use design time width
    			}
    
    			GetElementsSize();
    			ResizeForm();
    		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_TextChanged(object sender, EventArgs e)
		{
			GetElementsSize();
			ResizeForm();
		}
    		//This gets the size of the X and the border of the form
    		private void GetElementsSize()
    		{
    			var g = this.CreateGraphics();
    
    			// Get the size of the close button.
    			if (SetRenderer(VisualStyleElement.Window.CloseButton.Normal))
    			{
    				AllButtonsAndPadding += renderer.GetPartSize(g, ThemeSizeType.True).Width;
    			}
    
    			// Get the size of the minimize button.
    			if (this.MinimizeBox && SetRenderer(VisualStyleElement.Window.MinButton.Normal))
    			{
    				AllButtonsAndPadding += renderer.GetPartSize(g, ThemeSizeType.True).Width;
    			}
    
    			// Get the size of the maximize button.
    			if (this.MaximizeBox && SetRenderer(VisualStyleElement.Window.MaxButton.Normal))
    			{
    				AllButtonsAndPadding += renderer.GetPartSize(g, ThemeSizeType.True).Width;
    			}
    
    			// Get the size of the icon only if it is actually going to be displayed.
    			if (this.ShowIcon && this.ControlBox && (this.FormBorderStyle == FormBorderStyle.Fixed3D || this.FormBorderStyle == FormBorderStyle.Sizable || this.FormBorderStyle == FormBorderStyle.FixedSingle))
    			{
    				AllButtonsAndPadding += this.Icon.Width;
    			}
    
    			// Get the thickness of the left and right window frame.
    			if (SetRenderer(VisualStyleElement.Window.FrameLeft.Active))
    			{
    				AllButtonsAndPadding += (renderer.GetPartSize(g, ThemeSizeType.True).Width) * 2; //Borders on both side
    			}
    		}
    
    		//This resizes the form
    		private void ResizeForm()
    		{
    			//widen window if title length requires it else contract it to the minWidth if required.
    			int newWidth = TextRenderer.MeasureText(this.Text, SystemFonts.CaptionFont).Width + AllButtonsAndPadding;
    			if (newWidth > minWidth)
    			{
    				this.Width = newWidth;
    			}
    			else
    			{
    				this.Width = minWidth;
    			}
    		}
    
    		//This sets the renderer to the element we want
    		private bool SetRenderer(VisualStyleElement element)
    		{
    			try
    			{
    				bool bReturn = VisualStyleRenderer.IsElementDefined(element);
    				if (bReturn && renderer == null)
    				{
    					renderer = new VisualStyleRenderer(element);
    				}
    				else
    				{
    					renderer.SetParameters(element);
    				}
    				return bReturn;
    			}
    			catch (Exception)
    			{
    				return false;
    			}
    		}
    	}
    }
