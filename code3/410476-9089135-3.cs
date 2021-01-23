    [Category("Custom User Controls")]
    public class ListBoxWithTitle : ListBox
    {
        private Label titleLabel;
        public ListBoxWithTitle()
        {
            this.SizeChanged +=new EventHandler(SizeSet);
            this.LocationChanged +=new EventHandler(LocationSet);
            this.ParentChanged += new EventHandler(ParentSet);
            
        }
        public string TitleLabelText
        {
            get;
            set;
        }
        //Ensures the Size, Location and Parent have been set before adding text
        bool isSizeSet = false;
        bool isLocationSet = false;
        bool isParentSet = false;
        private void SizeSet(object sender, EventArgs e)
        {
            isSizeSet = true;
            if (isSizeSet && isLocationSet && isParentSet)
            {
                PositionLabel();
            }
        }
        private void LocationSet(object sender, EventArgs e)
        {
            isLocationSet = true;
            if (isSizeSet && isLocationSet && isParentSet)
            {
                PositionLabel();
            }
        }
        private void ParentSet(object sender, EventArgs e)
        {
            isParentSet = true;
            if (isSizeSet && isLocationSet && isParentSet)
            {
                PositionLabel();
            }
        }
        private void PositionLabel()
        {
            //Initializes text label
            titleLabel = new Label();
            //Positions the text 10 pixels below the Listbox.
            titleLabel.Location = new Point(this.Location.X, this.Location.Y + this.Size.Height + 10);
            titleLabel.AutoSize = true;
            titleLabel.Text = TitleLabelText;
            this.Parent.Controls.Add(titleLabel);
        }
    }
