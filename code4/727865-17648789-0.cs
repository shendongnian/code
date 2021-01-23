    private void keyDownCallback(object sender, KeyEventArgs e) {
        if (e.KeyCode.ToString() == "Z") {
            if (!timer1.Enabled)
                timer1.Enabled = true;
        } else if (e.KeyCode.ToString() == "X") {
            if (timer1.Enabled)
                timer1.Enabled = false;
        }
    }
