    private void buttons_Click(object sender, EventArgs e)
        {
            var theButton = (Button) sender;
            if (theButton.BackColor != Color.Lime)
            {
                theButton.BackColor = Color.Lime;
            }
            else
            {
                theButton.BackColor = Color.White;
            }
        }
