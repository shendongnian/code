    public class TagLayoutPanel : FlowLayoutPanel
    {
        //local variables/controls
        private TextBox _entryBox;
        private Dictionary<string,string> _currentTags;
        //events
        public delegate void TagsUpdatedHandler(TagEventArgs e);
        public event TagsUpdatedHandler TagsUpdated;
        //constructor(s)
        public TagLayoutPanel()
        {
            Init();
        }
        public List<string> GetCurrentTags()
        {
            var lst = new List<string>();
            if (_currentTags != null)
                lst = _currentTags.Keys.ToList();
            return lst;
        }
        private void Init()
        {
            _currentTags = new Dictionary<string, string>();
            //Entry box
            this.Padding = new Padding(3);
            this.BackColor = Color.White;
            _entryBox = new TextBox();
            _entryBox.BackColor = Color.White;
            _entryBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            _entryBox.KeyUp += _entryBox_KeyUp;
            this.Controls.Add(_entryBox);
        }
        private void _entryBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var tag = _entryBox.Text;
                if (!string.IsNullOrEmpty(tag))
                {
                    this.AddTag(tag);
                    _entryBox.Text = String.Empty;
                }
            }
        }
        protected override void OnGotFocus(EventArgs e)
        {
            //Set focus to the textentry box.
            base.OnGotFocus(e);
            this._entryBox.Focus();
        }
        public void AddTag(string tag)
        {
            bool added = false;
            if (!_currentTags.ContainsKey(tag))
            {
                _currentTags.Add(tag, tag);
                added = true;
            }
            if(added)
            {
                Redraw();
                Notify();
            }
        }
        private void Notify()
        {
            if(TagsUpdated != null)
                TagsUpdated(new TagEventArgs(GetCurrentTags().ToArray()));
        }
        public void Redraw()
        {
            this.Controls.Clear();
            foreach (var tag in _currentTags.Keys)
            {
                DrawTag(tag);
            }
            AddEntry();
        }
        private void AddEntry()
        {
            this.Controls.Add(_entryBox);
            _entryBox.Focus();
        }
        public void DrawTag(string tag)
        {
            var lbl = new Label();
            lbl.MouseMove += lbl_MouseMove;
            lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lbl.BackColor = Color.LightGray;
            lbl.Name = "lbl_" + tag.Replace(" ", "");
            lbl.ImageAlign = ContentAlignment.TopRight;
            lbl.Text = tag;
            lbl.Tag = tag;
            lbl.Image = Resources.close_x; //Replace with your own image.
            lbl.Click += lbl_Click;
            this.Controls.Add(lbl);
        }
        private void lbl_Click(object sender, EventArgs e)
        {
            var lbl = (Label)sender;
            bool removed = false;
            foreach(var item in this.Controls)
            {
                if(item is Label)
                {
                    if(((Label)item).Tag.ToString() == lbl.Tag.ToString())
                    {
                        _currentTags.Remove(lbl.Tag.ToString());
                        removed = true;
                        break;
                    }
                }
            }
            if(removed)
            {
                Redraw();
                Notify();
            }
        }
        private void lbl_MouseMove(object sender, MouseEventArgs e)
        {
            var lbl = (Label)sender;
            var startImgX = lbl.Width - 20;
            var endImgY = lbl.Height - 15;
            if (e.X >= startImgX && e.Y <= endImgY)
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Hand;
            else
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Arrow;
        }
    }
    public class TagEventArgs : EventArgs
    {
        public string[] Tags { get; private set; }
        public TagEventArgs(string[] tags)
        {
            Tags = tags;
        }
    }
