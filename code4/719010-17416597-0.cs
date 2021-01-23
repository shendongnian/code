    public class ChatWindow : SplitContainer
    {
        private SplitContainer innerSpliter = new SplitContainer();
        public ChatWindow()
        {
            Type type = typeof(Panel);
            type.GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(innerSpliter.Panel2, true, null);
            //Initialize some properties
            innerSpliter.Parent = Panel2;
            innerSpliter.Panel2.AutoScroll = true;
            innerSpliter.Dock = DockStyle.Fill;
            SplitterDistance = 50;
            innerSpliter.SplitterDistance = 10;
            BorderStyle = BorderStyle.FixedSingle;
            innerSpliter.BorderStyle = BorderStyle.FixedSingle;
            //-----------------------------            
            Panel1.BackColor = Color.White;
            innerSpliter.Panel1.BackColor = innerSpliter.Panel2.BackColor = Color.White;
        }
        bool adding;
        private Binding GetTopBinding(RichTextBox richText)
        {
            Binding bind = new Binding("Top", richText, "Location");
            bind.Format += (s, e) =>
            {
                Binding b = s as Binding;                           
                if (adding)
                {
                    RichTextBox rtb = b.DataSource as RichTextBox;
                    if (rtb.TextLength == 0) { e.Value = ((Point)e.Value).Y; return; }
                    rtb.SuspendLayout();
                    rtb.SelectionStart = 0;
                    int i = rtb.SelectionFont.Height;
                    int belowIndex = 0;
                    while (belowIndex == 0&&i < rtb.Height-6)
                    {
                        belowIndex = rtb.GetCharIndexFromPosition(new Point(1, i++));
                    }                                        
                    float baseLine1 = 0.75f * i; //This is approximate
                    float baseLine2 = GetBaseLine(b.Control.Font, b.Control.CreateGraphics());//This is exact
                    b.Control.Tag = (baseLine1 > baseLine2 ? baseLine1 - baseLine2 - 2: 0);
                    e.Value = ((Point)e.Value).Y + (float)b.Control.Tag;
                    rtb.ResumeLayout(false);
                }
                else e.Value = ((Point)e.Value).Y + (float)b.Control.Tag;
            };
            return bind;
        }
        private Binding GetHeightBinding(RichTextBox richText)
        {
            Binding bind = new Binding("Height", richText, "Size");
            bind.Format += (s, e) =>
            {
                Binding b = s as Binding;
                e.Value = ((Size)e.Value).Height - b.Control.Top + ((RichTextBox) b.DataSource).Top;
            };
            return bind;
        }
        private Binding GetWidthBinding(Panel panel)
        {
            Binding bind = new Binding("Width", panel, "Size");
            bind.Format += (s, e) =>
            {                
                e.Value = ((Size)e.Value).Width;
            };
            return bind;
        }
        public void AddItem(string first, string second, string third)
        {
            adding = true;            
            RichTextBox richText = new RichTextBox();
            innerSpliter.Panel2.SuspendLayout();
            Panel1.SuspendLayout();
            innerSpliter.Panel1.SuspendLayout();
            richText.Dock = DockStyle.Top;
            richText.Width = innerSpliter.Panel2.Width;            
            richText.ContentsResized += ContentsResized;                               
            richText.BorderStyle = BorderStyle.None;
            Label lbl = new Label() { Text = first, AutoSize = false, ForeColor = Color.BlueViolet};            
            lbl.DataBindings.Add(GetHeightBinding(richText));                      
            lbl.DataBindings.Add(GetTopBinding(richText));            
            lbl.DataBindings.Add(GetWidthBinding(Panel1));
            lbl.Parent = Panel1;            
            lbl = new Label() { Text = second,  AutoSize = false, ForeColor = Color.BlueViolet };            
            lbl.DataBindings.Add(GetHeightBinding(richText));            
            lbl.DataBindings.Add(GetTopBinding(richText));            
            lbl.DataBindings.Add(GetWidthBinding(innerSpliter.Panel1));
            lbl.Parent = innerSpliter.Panel1;            
            richText.Visible = false;
            richText.Parent = innerSpliter.Panel2;
            richText.Visible = true;
            richText.Rtf = third;            
            richText.BringToFront();             
            innerSpliter.Panel1.ResumeLayout(true);
            innerSpliter.Panel2.ResumeLayout(true);
            Panel1.ResumeLayout(true);
            innerSpliter.Panel2.ScrollControlIntoView(innerSpliter.Panel2.Controls[0]);
            adding = false;
        }
        private void ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            ((RichTextBox)sender).Height = e.NewRectangle.Height + 6;
        }
        private float GetBaseLine(Font font, Graphics g)
        {
            int lineSpacing = font.FontFamily.GetLineSpacing(font.Style);
            int cellAscent = font.FontFamily.GetCellAscent(font.Style);
            return font.GetHeight(g) * cellAscent / lineSpacing;
        }
    }
    //I provide only 1 AddItem() method, in fact it's enough because normally we don't have requirement to remove a chat line once it's typed and sent.
    chatWindow.AddItem(DateTime.Now.ToString(), "User name", "Rtf text");
