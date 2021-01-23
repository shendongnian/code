        if (protInfo.Name == "QCOM" )
        {
            BroadCast = new CheckBox();
            BroadCast.Text = "Date/Time Broadcast";
            BroadCast.Checked = FlagSet(CurrentFilter, (Byte)Filter.DateTimeBC);
            ToolStripControlHost Ch1 = new ToolStripControlHost(BroadCast);
            GenPoll = new CheckBox();
            GenPoll.Text = "Status Poll";
            GenPoll.Checked = FlagSet(CurrentFilter, (Byte)Filter.GenStatusPoll);
            ToolStripControlHost Ch2 = new ToolStripControlHost(GenPoll);
            GenPollResp = new CheckBox();
            GenPollResp.Text = "Status Poll Response";
            GenPollResp.Checked = FlagSet(CurrentFilter, (Byte)Filter.GenStatusResponse);
            ToolStripControlHost Ch3 = new ToolStripControlHost(GenPollResp);
            Button btnDone = new Button();
            btnDone.Text = "Done";
            ToolStripControlHost Ch4 = new ToolStripControlHost(btnDone);
            btnDone.Click += new EventHandler(btnDone_Click);
            contextMenuStrip1.Items.Clear();
            contextMenuStrip1.Items.Add(Ch1);
            contextMenuStrip1.Items.Add(Ch2);
            contextMenuStrip1.Items.Add(Ch3);
            contextMenuStrip1.Items.Add(Ch4);
            contextMenuStrip1.Enabled = true;
            filterToolStripMenuItem.Enabled = true;
        }
        else
        {
            filterToolStripMenuItem.Enabled = false;
        }
