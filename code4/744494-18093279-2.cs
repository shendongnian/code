        public Form1()
        {
            InitializeComponent();
            AttachHandler(comboBox1);
            AttachHandler(comboBox2);
            AttachHandler(comboBox3);
            AttachHandler(comboBox4);
            AttachHandler(comboBox5);
        }
        void AttachHandler(ComboBox combo)
        {
            combo.DrawMode = DrawMode.OwnerDrawFixed;
            combo.DrawItem += new DrawItemEventHandler(cmb_Type_DrawItem);
        }
        //using mycombo to make combobox variable
        void cmb_Type_DrawItem(object sender, DrawItemEventArgs e)
        {
            var mycombo = (ComboBox) sender;  // This is what I meant
            e.DrawBackground();
            string a = mycombo.Items[e.Index].ToString();
            if (mycombo.Items[e.Index].ToString().Substring(0, 1) == "-")
            {
                e.Graphics.DrawLine(Pens.Black, new Point(e.Bounds.Left, e.Bounds.Bottom - 1),
                new Point(e.Bounds.Right, e.Bounds.Bottom - 1));
                a = a.Substring(1, a.Length - 1);
            }
            TextRenderer.DrawText(e.Graphics, a, mycombo.Font, e.Bounds, mycombo.ForeColor, 
                         TextFormatFlags.Left);
            e.DrawFocusRectangle();
        }
