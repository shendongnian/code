    private void button3_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("You are about to delete application: "+ Environment.NewLine  + _applicationListBox.SelectedItem +Environment.NewLine + " Are you sure you want to delete the application?", "", MessageBoxButtons.YesNo) == DialogResult.No)
        {
            MessageBox.Show("The application will not be deleted.", "", MessageBoxButtons.OK);
        }
        else if (this._applicationListBox.SelectedIndex >= 0)
        {
            var item = this.GetCurrentApplication();
            _toepassingIniFile.ToePassingen.Remove(item);
            _applicationListBox.DataSource = null;
            _applicationListBox.DataSource = _toepassingIniFile.ToePassingen;
        }
    }
