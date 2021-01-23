        private Point mouseDownPos;
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e) {
            mouseDownPos = e.Location;
        }
        private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e) {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left) {
                if (Math.Abs(e.X - mouseDownPos.X) >= SystemInformation.DoubleClickSize.Width ||
                    Math.Abs(e.Y - mouseDownPos.Y) >= SystemInformation.DoubleClickSize.Height) {
                    // Start dragging
                    //...
                }
            }
        }
