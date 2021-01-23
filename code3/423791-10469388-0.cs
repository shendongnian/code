        private void listview_ClientSizeChanged(object sender, EventArgs e)
        {
            listview.BeginUpdate();
            if (IsScrollbarVisible(listview.Handle))
            {
                columnHeader1.Width = listview.ClientRectangle.Width - (columnHeader2.Width + columnHeader3.Width);
            }
            listview.EndUpdate();
        }
