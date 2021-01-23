            if (e.Button == MouseButtons.Left && _drawStarted && _selection.Size != new Size())
            {
                //Rectangle temp = _selection;
                PictureEditViewInfo viewInfo = originalPictureEdit.GetViewInfo() as PictureEditViewInfo;
                PropertyInfo pr = viewInfo.GetType().GetProperty("HScrollBarPosition", BindingFlags.Instance | BindingFlags.NonPublic);
                int fHScrollBarPosition = (int)pr.GetValue(viewInfo, null);
                pr = viewInfo.GetType().GetProperty("VScrollBarPosition", BindingFlags.Instance | BindingFlags.NonPublic);
                int fVScrollBarPosition = (int)pr.GetValue(viewInfo, null);
                _selection.X += fHScrollBarPosition;
                _selection.Y += fVScrollBarPosition;
                Crop();
            }
            Cursor = Cursors.Default;
            
            _drawStarted = false;
        }
