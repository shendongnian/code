    public class CustomLabel : Label
    {
        public CustomLabel()
        {
            TopLeftText = BottomRightText = "";
            AutoSize = false;
        }
        public string TopLeftText {get;set;}        
        public string BottomRightText {get;set;}                
        protected override void OnPaint(PaintEventArgs e)
        {
            using (StringFormat sf = new StringFormat() { LineAlignment = StringAlignment.Near})
            {
                using(SolidBrush brush = new SolidBrush(ForeColor)){
                  e.Graphics.DrawString(TopLeftText, Font, brush, ClientRectangle, sf);
                  sf.LineAlignment = StringAlignment.Far;
                  sf.Alignment =  StringAlignment.Far;
                  e.Graphics.DrawString(BottomRightText, Font, brush, ClientRectangle, sf);
                }
            }
        }
    }
    //use it:
    //first, set its size to what you want.
    customLabel1.TopLeftText = house.Name;
    customLabel2.BottomRightText = house.Number;
