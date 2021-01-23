        private void posLB_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                String s = e.Data.GetData(DataFormats.Text) as String;
                if (!String.IsNullOrEmpty(s))
                    posLB.Text = s;
            }
        }
