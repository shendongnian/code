    private void studentCheckbox_CheckedChanged(object sender, EventArgs e)
    {
        if (studentCheckbox.CheckState == CheckState.Checked)
        {
            foreach (Student student in people.OfType<Student>())
            {
                if (student.Compare(SearchTextBox.Text) == 0)
                {
                    resultsListBox.Items.Add(student.Forename);
                }
            }
        }
        else
        {}
    }
