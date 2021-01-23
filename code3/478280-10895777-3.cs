    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.SuspendLayout();
            List<Bitmap> Smiles = new List<Bitmap>();//Insert in the list your bitmap image for smiles
            ToolStripSplitButton _toolStripSplitButton = new ToolStripSplitButton();
            _toolStripSplitButton.Size = new Size(23, 23);
            //_toolStripButton.Image = myImage; //Insert the image for the stripSplitButton
            ToolStrip _toolStrip = new ToolStrip();
            _toolStrip.Size = new Size(ClientSize.Width, 10);
            _toolStrip.Location = new Point(0, this.ClientSize.Height - _toolStrip.Height);
            _toolStrip.BackColor = Color.LightGray;
            _toolStrip.Dock = DockStyle.Bottom;
            _toolStrip.Items.AddRange(new ToolStripItem[] { _toolStripSplitButton});
            SmileBox smilebox = new SmileBox(new Point(_toolStripSplitButton.Bounds.Location.X, _toolStrip.Location.Y), 6);
            smilebox.Visible = false;
            Controls.Add(smilebox);
            foreach (Bitmap bmp in Smiles)
                smilebox.AddItem(bmp);
            _toolStripSplitButton.Click += new EventHandler(delegate(object sender, EventArgs e)
                {
                    smilebox.Visible = true;
                });
            this.Controls.Add(_toolStrip);
            this.ResumeLayout();
        }
        void _toolStripButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
    class SmileBox : Panel
    {
        public List<Item> Items
        {
            get;
            set;
        }
        Size _ItemSpace = new Size(14, 14); 
        Point _ItemLocation;
        int _rowelements = 0;
        public SmileBox(Point Location, int RowElements)
        {
            Location = new Point(Location.X, Location.Y - _ItemSpace.Height);
            Height = _ItemSpace.Height;
            Width = _ItemSpace.Width * RowElements;
            _ItemLocation = new Point(0, 0);
            _rowelements = RowElements;
        }
        int count = 1;
        public void AddItem(Bitmap Image)
        {
            Item item = new Item(_ItemSpace, _ItemLocation, Image);
            if (_ItemLocation.X == Width)
                _ItemLocation = new Point(0, _ItemLocation.Y);
            else
                _ItemLocation = new Point(_ItemLocation.X + _ItemSpace.Width, _ItemLocation.Y);
            if (count == _rowelements)
            {
                _ItemLocation = new Point(_ItemLocation.X, _ItemLocation.Y + _ItemSpace.Height);
                Location = new Point(Location.X, Location.Y - _ItemSpace.Height);
                count = 1;
            }
            count++;
            Controls.Add(item);
        }
    }
    class Item : PictureBox
    {
        int _BorderSpace = 2;
        public Item(Size Size, Point Location, Bitmap Image)
        {
            this.Size = new Size(Size.Width - 2 * _BorderSpace, Size.Height - 2 * _BorderSpace);
            this.Location = new Point(Location.X + _BorderSpace, Location.Y + _BorderSpace);
            this.Image = Image;
            Click += new EventHandler(delegate(object sender, EventArgs e)
                  {
                      //Here what do you want to do when the user click on the smile
                  });
            MouseLeave += new EventHandler(delegate(object sender, EventArgs e)
                  {
                       Parent.Visible = false;
                  });
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.Focus();
            base.OnMouseDown(e);
        }
        protected override void OnEnter(EventArgs e)
        {
            this.Invalidate();
            base.OnEnter(e);
        }
        protected override void OnLeave(EventArgs e)
        {
            this.Invalidate();
            base.OnLeave(e);
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            if (this.Focused)
            {
                ClientRectangle.Inflate(-1, -1);
                Rectangle rect = ClientRectangle;
                ControlPaint.DrawFocusRectangle(pe.Graphics, rect);
            }
        }
    }
