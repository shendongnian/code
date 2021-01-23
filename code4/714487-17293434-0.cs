        private bool DraggingFromGrid = false;
        private System.Drawing.Point DraggingStartPoint = new System.Drawing.Point(  );
        void GridControlBrowser_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                DraggingFromGrid = true;
                DraggingStartPoint = new System.Drawing.Point(e.X, e.Y);
            }
        }
        void GridControlBrowser_MouseUp(object sender, MouseEventArgs e)
        {
            if (DraggingFromGrid)
            {
                DraggingFromGrid = false;
            }
        }
        void GridControlBrowser_MouseMove(object sender, MouseEventArgs e)
        {
            if (DraggingFromGrid)
            {
                if (System.Math.Abs(e.X - DraggingStartPoint.X) > 10 ||
                    System.Math.Abs(e.Y - DraggingStartPoint.Y) > 10)
                {
                    StartDragging();
                }
            }
        }
        private void StartDragging()
        {
            DraggingFromGrid = false;
            
            // create files
            var _criteria = this.GetSelectionFromGrid();
            var _files = new List<string>();
            ... retrieve filenames and store in _files List ...
            var _data = new DataObject(DataFormats.FileDrop, _files.ToArray());
            DoDragDrop(_data, DragDropEffects.Copy);
        }
'
