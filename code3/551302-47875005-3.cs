    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Windows.Forms;
    using Controles.Class;
    namespace Controles.Buttons
    {
    public class SansationRoundButton : Button
    {
        private TextRenderingHint _hint = TextRenderingHint.AntiAlias;
        public SansationRoundButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Font = new System.Drawing.Font("Sansation", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.UseVisualStyleBackColor = true;
        }
        public TextRenderingHint TextRenderingHint
        {
            get { return this._hint; }
            set { this._hint = value; }
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            e.Graphics.TextRenderingHint = this.TextRenderingHint;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawRoundedRectangle(new Pen(Color.Black), 0, 0, this.Width - 1, this.Height - 1, 10);
            e.Graphics.FillRoundedRectangle(new SolidBrush(this.BackColor), 0, 0, this.Width -1, this.Height - 1, 10);
            StringFormat sr = BaseControl.CreateStringFormat(this, this.TextAlign, false, this.UseMnemonic);
            e.Graphics.DrawString(this.Text, Font, new SolidBrush(ForeColor), ClientRectangle, sr);
        }
        public new bool ShowKeyboardCues
        {
            get
            {
                return base.ShowKeyboardCues;
            }
        }
    }
    }
