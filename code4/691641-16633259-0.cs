        public List<UserControl> Submenus = new List<UserControl>();
        Multiplayer_Menu MPM;
        enum At { Left, Right }
        At Current = At.Right;
        At Go_to = At.Right;
        int Submenu_Index = 0;
        bool done = false;
        public void Load_Submenus()
        {
            Multiplayer_Menu MM = new Multiplayer_Menu(this);
            MainMenu.Controls.Add(MM);
            MM.Location = new Point(MainMenu.Size.Width, 0);
            MM.Visible = false;
            Submenus.Add(MM);
            PictureBox PB = new PictureBox();
            MainMenu.Controls.Add(PB);
            PB.Location = new Point(MainMenu.Size.Width, 0);
            PB.Size = new System.Drawing.Size(924, 736);
            PB.SizeMode = PictureBoxSizeMode.StretchImage;
            PB.ImageLocation = "http://www.taloreal.com/Earth%20Rotation/Rotating.gif";
            PB.Visible = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Load_Submenus();
        }
        public void MML_Multiplayer_Click(object sender, EventArgs e)
        {
            Submenus[Submenu_Index].Visible = false;
            if (Current == At.Left)
                Go_to = At.Right;
            if (Current == At.Right)
                Go_to = At.Left;
            ShowHideMenus.Enabled = true;
            Submenu_Index = 0;
        }
        private void ShowHideMenus_Tick(object sender, EventArgs e)
        { 
            Point P = new Point(MainMenu.Location.X, MainMenu.Location.Y);
            Size S = new Size(MainMenu.Size.Width, MainMenu.Size.Height);
            if (Go_to == At.Left)
            {
                P = new Point(P.X - 30, P.Y);
                S = new Size(S.Width + 30, S.Height);
                if (P.X == 0)
                {
                    Submenus[Submenu_Index].Visible = true;
                    ShowHideMenus.Enabled = false;
                    Current = Go_to;
                }
            }
            if (Go_to == At.Right)
            {
                P = new Point(P.X + 30, P.Y);
                S = new Size(S.Width - 30, S.Height);
                if (P.X == 930)
                {
                    ShowHideMenus.Enabled = false;
                    Current = Go_to;
                }
            }
            Reposition_Menu(P, S);
        }
        void Reposition_Menu(Point P, Size S)
        {
            MainMenu.Location = P;
            MainMenu.Size = S;
        }
