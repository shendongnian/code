    public class ListPanel : Panel
    {
        public ListPanel()
        {
            AutoScroll = true;
        }
        private List<ListPanelItem> items = new List<ListPanelItem>();
        public void AddItem(ListPanelItem item)
        {
            item.Index = items.Count;
            items.Add(item);            
            Controls.Add(item);
            item.BringToFront();
            item.Click += ItemClicked;
        }
        public int SelectedIndex { get; set; }
        public ListPanelItem SelectedItem { get; set; }
        private void ItemClicked(object sender, EventArgs e)
        {
            ListPanelItem item = sender as ListPanelItem;
            if (SelectedItem != null) SelectedItem.Selected = false;
            SelectedItem = item;
            SelectedIndex = item.Index;
            item.Selected = true;
            if (ItemClick != null) ItemClick(this, new ItemClickEventArgs() {Item = item});
        }
        public class ItemClickEventArgs : EventArgs
        {
            public ListPanelItem Item { get; set; }
        }
        public delegate void ItemClickEventHandler(object sender, ItemClickEventArgs e);
        public event ItemClickEventHandler ItemClick;
    }
    //Here is the class for ListPanelItem
    public class ListPanelItem : Panel
    {
        public ListPanelItem()
        {
            DoubleBuffered = true;
            ImageSize = new Size(100, 100);
            CaptionColor = Color.Blue;
            ContentColor = Color.Green;
            CaptionFont = new Font(Font.FontFamily, 13, FontStyle.Bold | FontStyle.Underline);
            ContentFont = new Font(Font.FontFamily, 10, FontStyle.Regular);
            Dock = DockStyle.Top;
            SelectedColor = Color.Orange;
            HoverColor = Color.Yellow;
        }
        private bool selected;
        public Size ImageSize { get; set; }
        public Image Image { get; set; }
        public string Caption { get; set; }
        public string Content { get; set; }
        public Color CaptionColor { get; set; }
        public Color ContentColor { get; set; }
        public Font CaptionFont { get; set; }
        public Font ContentFont { get; set; }
        public int Index { get; set; }
        public bool Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                Invalidate();
            }
        }
        public Color SelectedColor { get; set; }
        public Color HoverColor { get; set; }        
        protected override void OnPaint(PaintEventArgs e)
        {
            Color color1 = mouseOver ? Color.FromArgb(0, HoverColor) : Color.FromArgb(0, SelectedColor);
            Color color2 = mouseOver ? HoverColor : SelectedColor;
            Rectangle actualRect = new Rectangle(ClientRectangle.Left, ClientRectangle.Top, ClientRectangle.Width, ClientRectangle.Height - 2);
            using (System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(ClientRectangle, color1, color2, 90))
            {                                
                if (mouseOver)
                {                                        
                    e.Graphics.FillRectangle(brush, actualRect);
                }
                else if (Selected)
                {
                    e.Graphics.FillRectangle(brush, actualRect);
                }
            }
            if (Image != null)
            {
                e.Graphics.DrawImage(Image, new Rectangle(new Point(5, 5), ImageSize));
            }
            //Draw caption
            StringFormat sf = new StringFormat() { LineAlignment = StringAlignment.Center};            
            e.Graphics.DrawString(Caption, CaptionFont, new SolidBrush(CaptionColor), new RectangleF(ImageSize.Width + 10, 5, Width - ImageSize.Width - 10, CaptionFont.SizeInPoints * 1.5f), sf);
            //Draw content
            int textWidth = Width - ImageSize.Width - 10;
            SizeF textSize = e.Graphics.MeasureString(Content, ContentFont);
            float textHeight = (textSize.Width / textWidth) * textSize.Height + textSize.Height;
            int dynamicHeight = (int)(CaptionFont.SizeInPoints * 1.5) + (int)textHeight + 1;
            if (Height != dynamicHeight)
            {
                Height = dynamicHeight > ImageSize.Height + 10 ? dynamicHeight : ImageSize.Height + 10;
            }
            e.Graphics.DrawString(Content, ContentFont, new SolidBrush(ContentColor), new RectangleF(ImageSize.Width + 10, CaptionFont.SizeInPoints * 1.5f + 5, Width - ImageSize.Width - 10, textHeight));
            e.Graphics.DrawLine(Pens.Silver, new Point(ClientRectangle.Left, ClientRectangle.Bottom-1), new Point(ClientRectangle.Right, ClientRectangle.Bottom-1));
            base.OnPaint(e);
        }        
        bool mouseOver;
        protected override void OnMouseEnter(EventArgs e)
        {
            mouseOver = true;
            base.OnMouseEnter(e);
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            mouseOver = false;
            base.OnMouseLeave(e);
            Invalidate();
        }
    }
