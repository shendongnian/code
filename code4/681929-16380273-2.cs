    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace Font_Display
    {
        public class Test : System.Windows.Forms.Form
        {
            private Font head;
            private System.Windows.Forms.ListBox list;
            private System.ComponentModel.Container components = null;
    
            public Test()
            {
                InitializeComponent();
    
                head = new Font("Arial", 10, GraphicsUnit.Pixel);
            }
    
            protected override void Dispose(bool disposing)
            {
                if (disposing) {
                    if (components != null) {
                        components.Dispose();
                    }
                }
                base.Dispose(disposing);
            }
    
            #region Windows Form Designer generated code
            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.list = new System.Windows.Forms.ListBox();
                this.SuspendLayout();
                // 
                // list
                // 
                this.list.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
                this.list.IntegralHeight = false;
                this.list.Location = new System.Drawing.Point(12, 12);
                this.list.Name = "list";
                this.list.Size = new System.Drawing.Size(604, 323);
                this.list.TabIndex = 0;
                this.list.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.list_DrawItem);
                this.list.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.list_MeasureItem);
                // 
                // Test
                // 
                this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
                this.ClientSize = new System.Drawing.Size(520, 358);
                this.Controls.Add(this.list);
                this.Name = "Test";
                this.Text = "Display";
                this.Load += new System.EventHandler(this.Test_Load);
                this.Resize += new System.EventHandler(this.Display_Resize);
                this.ResumeLayout(false);
    
            }
            #endregion
    
            [STAThread]
            static void Main()
            {
                Application.Run(new Test());
            }
    
            private void Test_Load(object sender, EventArgs e)
            {
                try {
                    // Loop all font families
                    FontFamily[] families = FontFamily.Families;
                    foreach (FontFamily family in families) {
                        try { list.Items.Add(new Font(family, 20, FontStyle.Regular, GraphicsUnit.Pixel)); continue; }
                        catch { }
                    }
    
                    Display_Resize(this, EventArgs.Empty);
                }
                catch {
                }
            }
    
            private void Display_Resize(object sender, System.EventArgs e)
            {
                Rectangle r = this.ClientRectangle;
                list.SetBounds(list.Left,
                    list.Top,
                    r.Width - (list.Left * 2),
                    r.Height - (list.Top + list.Left));
            }
    
            public string TextValue = "Example String";
    
            public StringFormat Format
            {
                get
                {
                    StringFormat format = StringFormat.GenericTypographic;
                    format.FormatFlags |= StringFormatFlags.NoWrap;
                    return format;
                }
            }
    
            private void list_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
            {
                Brush back = null;
                Brush fore = null;
                Brush htext = null;
                Rectangle r;
    
                try {
                    Font font = (Font)list.Items[e.Index];
    
                    // Loop
                    if ((e.State & DrawItemState.Selected) != 0) {
                        back = new SolidBrush(Color.DarkBlue);
                        fore = new SolidBrush(Color.White);
                        htext = new SolidBrush(Color.Orange);
                    }
                    else {
                        back = new SolidBrush(Color.White);
                        fore = new SolidBrush(Color.Black);
                        htext = new SolidBrush(Color.DarkRed);
                    }
    
                    // Fill the rect
                    e.Graphics.FillRectangle(back, e.Bounds);
    
                    // Get the size of the header
                    SizeF szHeader = e.Graphics.MeasureString(font.Name, head, int.MaxValue, Format);
                    SizeF szText = e.Graphics.MeasureString(TextValue, font, int.MaxValue, Format);
    
                    // Draw the string
                    r = e.Bounds;
                    r.Height = (int)szHeader.Height;
                    e.Graphics.DrawString(font.Name, head, htext, r, Format);
    
                    // Draw the string
                    r = e.Bounds;
                    r.Y = (int)(e.Bounds.Y + szHeader.Height);
                    r.Height = (int)szText.Height;
                    e.Graphics.DrawString(TextValue, font, fore, r, Format);
                }
                catch {
                }
                finally {
                    if (fore != null) fore.Dispose();
                    if (back != null) back.Dispose();
                    if (htext != null) htext.Dispose();
                }
            }
    
            private void list_MeasureItem(object sender, System.Windows.Forms.MeasureItemEventArgs e)
            {
                try {
                    Font font = (Font)list.Items[e.Index];
                    SizeF szHeader = e.Graphics.MeasureString(font.Name, head, int.MaxValue, Format);
                    SizeF szText = e.Graphics.MeasureString(TextValue, font, int.MaxValue, Format);
    
                    // Return it
                    e.ItemHeight = (int)(szText.Height + szHeader.Height);
                    e.ItemWidth = (int)Math.Max(szText.Width, szHeader.Width);
                }
                catch {
                }
            }
        }
    }
