    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Windows.Forms.VisualStyles;
    namespace WindowAutoAdapt
    {
    public partial class Form1 : Form
    {
        //A default value in case Application.RenderWithVisualStyles == false
        private int AllButtonsAndPadding = 0;
        private VisualStyleRenderer renderer = null;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."; //A big text in the title
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
            // Get the size of the icon.
            if (this.ShowIcon)
            {
                AllButtonsAndPadding += this.Icon.Width;
            }
            // Get the thickness of the left, bottom, 
            // and right window frame.
            if (SetRenderer(VisualStyleElement.Window.FrameLeft.Active))
            {
                AllButtonsAndPadding += (renderer.GetPartSize(g, ThemeSizeType.True).Width) * 2; //Borders on both side
            }
        }
        //This resizes the form
        private void ResizeForm()
        {
            this.Width = TextRenderer.MeasureText(this.Text, SystemFonts.CaptionFont).Width + AllButtonsAndPadding;
        }
        //This sets the renderer to the element we want
        private bool SetRenderer(VisualStyleElement element)
        {
            bool bReturn = VisualStyleRenderer.IsElementDefined(element);
            if (bReturn && renderer == null)
                renderer = new VisualStyleRenderer(element);
            else
                renderer.SetParameters(element);
            return bReturn;
        }
     }
     }
