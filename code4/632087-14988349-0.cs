    private void saveChangesButton_Click(object sender, EventArgs e)
    {
        Meeting m = new Meeting();
        m.title = textBoxTitle.Text;
        m.location = textBoxLocation.Text;
        m.startTime = textBoxStartTime.Text;
        m.endTime = textBoxEndTime.Text;
        m.notes = notesTextBox.Text;
        meetingArray[arraySize] = m;
        currentIndex = arraySize;
        arraySize++;
        meetingListBox.Enabled = true;
        textBoxTitle.Text = "";
        textBoxLocation.Text = "";
        textBoxStartTime.Text = "";
        textBoxEndTime.Text = "";
        notesTextBox.Text = "";
        meetingListBox.Items.Add(m);
        //Controls.Add(meetingListBox);   // You don't need to keep adding the control every time!
    }
