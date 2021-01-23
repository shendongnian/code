    using System;
    using System.Windows.Forms;
    namespace GujControls
    {
    public partial class LABEL_BIRTHDATE : Label
    {
        public LABEL_BIRTHDATE()
        {
            this.SuspendLayout();
            this.Font = GujWords.gujfont;
            this.Size = new System.Drawing.Size(70, 23);
            this.ResumeLayout();            
        }
       
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics, "NAME", Font,    ClientRectangle, ForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
        }
    }
    }
