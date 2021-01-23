        private MultiKeyGesture Shortcut1 = new MultiKeyGesture(new List<Keys> { Keys.A, Keys.B }, Keys.Control);
        private MultiKeyGesture Shortcut2 = new MultiKeyGesture(new List<Keys> { Keys.C, Keys.D }, Keys.Control);
        private MultiKeyGesture Shortcut3 = new MultiKeyGesture(new List<Keys> { Keys.E, Keys.F }, Keys.Control);
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (Shortcut1.Matches(e))
                BackColor = Color.Green;
            if (Shortcut2.Matches(e))
                BackColor = Color.Blue;
            if (Shortcut3.Matches(e))
                BackColor = Color.Red;
        }
