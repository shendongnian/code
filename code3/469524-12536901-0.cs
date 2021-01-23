        private void dataViewImages_MouseUp(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hit = dataViewImages.HitTest(e.X, e.Y);
            if (hit.Type != DataGridViewHitTestType.Cell)
               dataViewImages.ClearSelection();
        }
