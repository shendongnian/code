        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !TryClose();
        }
        private bool TryClose()
        {
            if (!saved)
            {
                if (usersaidyes)
                {
                    // save stuff
                    return true;
                }
                else if (usersaidno)
                {
                    // exit without saving
                    return false;
                }
                else
                {
                    // user cancelled closing
                    return true;
                }
            }
            return true;
        }
