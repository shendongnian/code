    private void lblSelect_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsDropdownHit(e) && cmsItems.Tag == null)
            {
                cmsItems.Width = lblSelect.Width;
                cmsItems.Show(lblSelect, 0, lblSelect.Height);
                cmsItems.Tag = "Shown";
            }
            else
            {
                cmsItems.Hide();
                cmsItems.Tag = null;
            }
        }
