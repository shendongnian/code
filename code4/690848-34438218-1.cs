     private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    {
                        SetTaskManager(Convert.ToBoolean(1));
                    }
                    break;
            }
