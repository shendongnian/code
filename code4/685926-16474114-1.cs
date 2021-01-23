        private void rtbComputerstatus_MouseMove(object sender, MouseEventArgs e)
        {
            if (rtbComputerstatus.SelectionColor.ToKnownColor() == KnownColor.Blue)
                rtbComputerstatus.Cursor = Cursors.Hand;
            else
                rtbComputerstatus.Cursor = Cursors.Default;
        }
