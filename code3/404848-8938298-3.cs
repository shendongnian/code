        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            // Save position of cursor, because it like to dissapering.
            int cursor = comboBox1.SelectionStart;
            //Clearing items in dropDown 
            comboBox1.Items.Clear();
            //Is something was searched before, cancel it!
            while (backgroundWorker1.IsBusy)
            {
                if (!backgroundWorker1.CancellationPending)
                {
                    backgroundWorker1.CancelAsync();
                }
            }
            // And search new one 
            backgroundWorker1.RunWorkerAsync(comboBox1.Text);
            // And bring back cursor to live
            comboBox1.SelectionStart = cursor;
        }
