    private void CheckBoxCheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkBox = (CheckBox) sender;
        if (checkBox.Checked)
        {
            Timer timer = new Timer {Interval = 1000};
            timer.Tick += Jogger;
            timer.Start();
            timer.Tag = new CheckboxCounter {CheckBox = checkBox, Time = 0};
            checkBox.Tag = timer;
        }
        else
        {
            Timer timer = checkBox.Tag as Timer;
            if (timer != null)
            {
                timer.Tag = null;
                timer.Stop();
                timer.Dispose();
                checkBox.Tag = null;
            }
        }
    }
