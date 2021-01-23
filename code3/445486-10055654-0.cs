    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Windows.Forms.VisualStyles;
    using System.Runtime.InteropServices;
    
    class MyDateTimePicker : DateTimePicker {
        private TextBox editbox;
        private int buttonWidth;
    
        public MyDateTimePicker() {
            editbox = new TextBox();
            editbox.BorderStyle = BorderStyle.None;
            editbox.BackColor = Color.Gold;   // debugging
            this.Controls.Add(editbox);
        }
        public override Font Font {
            get { return base.Font; }
            set { base.Font = editbox.Font = value; }
        }
        protected override void OnResize(EventArgs e) {
            if (buttonWidth == 0) measureButtonWidth();
            var margin = (this.ClientSize.Height - editbox.PreferredHeight) / 2;
            editbox.Location = new Point(margin, margin);
            editbox.Width = this.ClientSize.Width - margin - buttonWidth;
            base.OnResize(e);
        }
        private void measureButtonWidth() {
            if (!Application.RenderWithVisualStyles) buttonWidth = 21;   // TODO: measure
            else {
                var renderer = new VisualStyleRenderer("DATEPICKER", 3, 1);
                using (var gr = CreateGraphics()) {
                    buttonWidth = renderer.GetPartSize(gr, ThemeSizeType.True).Height;
                }
            }
        }
        protected override void Dispose(bool disposing) {
            if (disposing) editbox.Dispose();
            base.Dispose(disposing);
        }
    }
