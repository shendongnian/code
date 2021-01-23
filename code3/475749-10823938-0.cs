    public void SetToSelected()
            {
                SelectedCheckBox.Checked = true;
                PictureHolder.Focus();
            }
    private void PictureHolder_Click(object sender, EventArgs e)
            {
                BackColor = BackColor == Color.Black ? Color.Transparent : Color.Black;
    
                // TODO: Implement multi select features;
    
                if ((Control.ModifierKeys & Keys.Shift) != 0)
                {
                    // Set the end selection index.
                }
                else
                {
                    // Set the start selection index.
                }
    
                PictureHolder.Focus();
            }
    // subscribe to picture box's PreviewKeyDown
    
     public event PreviewKeyDownEventHandler OnPicBoxKeyDown;
     private void OnPicBoxPrevKeyDown(object sender, PreviewKeyDownEventArgs e)
            {
                if (OnPicBoxKeyDown != null)
                {
                    OnPicBoxKeyDown(sender, e);
                }
            }
