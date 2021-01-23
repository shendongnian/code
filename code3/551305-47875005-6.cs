    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Windows.Forms;
    using punto_de_ventea.Class;
    
    namespace Controles.Buttons
    {
        /// <summary>
        /// Clase personalizada button.
        /// Jorge Arturo Avilés Nuñez
        /// Zapopan, Jalisco, México
        /// 18-DIC-2017
        /// </summary>
        public class SansationRoundButton : Button
        {
            #region members
            private TextRenderingHint _hint = TextRenderingHint.AntiAlias;
            private const int FlagMouseOver = 0x0001;
            private const int FlagMouseDown = 0x0002;
            private int state = 0;
            #endregion
            #region Constructor
            public SansationRoundButton()
            {
                this.FlatStyle = FlatStyle.Flat;
                this.FlatAppearance.BorderSize = 0;
                this.Font = new System.Drawing.Font("Sansation", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
                this.UseVisualStyleBackColor = true;
                this.Cursor = Cursors.Hand;
            }
            #endregion  
            #region Internal methods and properties
            internal bool OwnerDraw
            {
                get
                {
                    return FlatStyle != FlatStyle.System;
                }
            }
            internal bool MouseIsOver
            {
                get
                {
                    return GetFlag(FlagMouseOver);
                }
            }
            #endregion
            #region Private methods
            private bool GetFlag(int flag)
            {
                return ((state & flag) == flag);
            }
            private void SetFlag(int flag, bool value)
            {
                bool oldValue = ((state & flag) != 0);
                if (value)
                    state |= flag;
                else
                    state &= ~flag;
                if (OwnerDraw && (flag & FlagMouseDown) != 0 && value != oldValue)
                    AccessibilityNotifyClients(AccessibleEvents.StateChange, -1);
            }
            #endregion
            #region Overrides
            protected override void OnMouseEnter(EventArgs e)
            {
                base.OnMouseEnter(e);
                SetFlag(FlagMouseOver, true);
            }
            protected override void OnMouseLeave(EventArgs e)
            {
                base.OnMouseLeave(e);
                SetFlag(FlagMouseOver, false);
            }
            protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
            {
                e.Graphics.Clear(Color.White);
                e.Graphics.TextRenderingHint = this.TextRenderingHint;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Color backColor = this.MouseIsOver ? this.BackColorMouseOver : this.BackColor;
                e.Graphics.DrawRoundedRectangle(new Pen(Color.Black), 0, 0, this.Width - 1, this.Height - 1, 10);
                e.Graphics.FillRoundedRectangle(new SolidBrush(backColor), 0, 0, this.Width -1, this.Height - 1, 10);
                StringFormat sr = BaseControl.CreateStringFormat(this, this.TextAlign, false, this.UseMnemonic);
                e.Graphics.DrawString(this.Text, Font, new SolidBrush(ForeColor), ClientRectangle, sr);
            }
            #endregion  
            #region public properties
            public TextRenderingHint TextRenderingHint
            {
                get { return this._hint; }
                set { this._hint = value; }
            }
            public new bool ShowKeyboardCues
            {
                get
                {
                    return base.ShowKeyboardCues;
                }
            }
            public Color BackColorMouseOver { get; set; } = Color.Red;
            #endregion
        }
    }
