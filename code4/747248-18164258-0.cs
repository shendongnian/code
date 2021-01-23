    public class CustomLabel : Label
    {
        string topLeftText, bottomRightText;
        Rectangle topLeftRect, bottomRightRect;
        public CustomLabel()
        {
            TopLeftText = BottomRightText = "";
            AutoSize = false;
        }
        public string TopLeftText
        {
            get { return topLeftText; }
            set {
                if (topLeftText != value)
                {
                    topLeftText = value;
                    Size sz = TextRenderer.MeasureText(value, Font);
                    topLeftRect = new Rectangle(0, 0, sz.Width, sz.Height);
                }
            }
        }
        public string BottomRightText
        {
            get { return bottomRightText; }
            set
            {
                if (bottomRightText != value)
                {
                    bottomRightText = value;
                    Size sz = TextRenderer.MeasureText(value, Font);
                    bottomRightRect = new Rectangle(ClientSize.Width - sz.Width, ClientSize.Height - sz.Height, sz.Width, sz.Height);
                }
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            using (StringFormat sf = new StringFormat() { LineAlignment = StringAlignment.Center })
            {
                e.Graphics.DrawString(TopLeftText, Font, new SolidBrush(ForeColor), topLeftRect, sf);
                e.Graphics.DrawString(BottomRightText, Font, new SolidBrush(ForeColor), bottomRightRect, sf);
            }
        }
    }
    //use it:
    //first, set its size to what you want.
    customLabel1.TopLeftText = house.Name;
    customLabel2.BottomRightText = house.Number;
