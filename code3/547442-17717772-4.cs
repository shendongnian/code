        private void DragCheck_MouseDownHandler(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            Control dgrid = sender as Control;
            foreach (CheckBox box in dgrid.Controls.OfType<CheckBox>())
            {
                box.Tag = null;
            }
            dgrid.MouseMove += DragMove_MouseMoveHandler;
        }
