    public class XButton : Button
    {
        public XButton()
        {
            UseVisualStyleBackColor = false;
            TextImageRelation = TextImageRelation.ImageAboveText;
        }
        public override string Text
        {
            get { return ""; }
            set { base.Text = value;}
        }
        public string LeftText { get; set; }
        public string RightText { get; set; }
        protected override void OnPaint(PaintEventArgs pevent)
        {            
            base.OnPaint(pevent);
            Rectangle rect = ClientRectangle;
            rect.Inflate(-5, -5);
            using (StringFormat sf = new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Far })
            {
                using (Brush brush = new SolidBrush(ForeColor))
                {
                    pevent.Graphics.DrawString(LeftText, Font, brush, rect, sf);
                    sf.Alignment = StringAlignment.Far;
                    pevent.Graphics.DrawString(RightText, Font, brush, rect, sf);
                }
            }
        }
    }
    //Use it
    xButton1.Image = yourImage;
    xButton1.LeftText = "How interesting winforms is";
    xButton2.RightText = "F12";
    //You can add more properties to this XButton class to control how it looks
