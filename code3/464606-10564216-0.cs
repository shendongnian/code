        public Form1() {
            InitializeComponent();
            var btn = new Button();
            btn.BackgroundImage = Properties.Resources.DropdownArrow;
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = Color.FromKnownColor(KnownColor.Window);
            btn.Parent = dateTimePicker1;
            btn.Dock = DockStyle.Right;
            btn.Click += showMonthCalendar;
            dateTimePicker1.Resize += delegate {
                btn.Width = btn.Height = dateTimePicker1.ClientSize.Height;
            };
        }
