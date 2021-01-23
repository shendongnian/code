            timer1.Stop();
            label1.Text = timer1.Enabled == false ?"timer disabled":"timer enabled";
            if (MessageBox.Show("Close program ?", "timers",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                //do stuff here if you want
            }
            timer1.Start();
            label1.Text = timer1.Enabled == false ? "timer disabled" : "timer enabled";
