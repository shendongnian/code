        bool selected;
        private void url_MouseDown(object sender, MouseEventArgs e)
        {
            url.ReadOnly = false;
            if (!selected)
            {
                selected = true;
                url.SelectAll();
            }
            else
            {
                selected = false;
                url.DeselectAll();
            }
        }
