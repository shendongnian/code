        private delegate void DragDropDelegate(String[] s);
        private void pnlImage_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void pnlImage_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                String[] a = (String[])e.Data.GetData(DataFormats.FileDrop);
                if (a != null)
                {
                    this.BeginInvoke(new DragDropDelegate(DelegateDragDrop), new Object[] { a });
                    this.Activate(); // This avoids some odd behaviour
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Error in DragDrop function: " + ex.Message);
            }
        }
        private void DelegateDragDrop(String[] files)
        {
            // Verify file formats and do something with the files.
        }
