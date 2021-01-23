    private void meetingListBox_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        Meeting m = meetingListBox.SelectedItem as Meeting;
        if (m != null) 
        {
            textBoxTitle.Text = m.title;
            //...etc for all your other text boxes.
        }
    }
