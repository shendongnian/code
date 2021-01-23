            TabPage tmpTabPage = new TabPage("Test");
			CustomRichTextBox tmpRichTextBox = new CustomRichTextBox();
			tmpRichTextBox.LoadFile(@"F:\aaData\IPACostData\R14TData\ACT0\1CALAEOSAudit_log.rtxt");
			// Attempted FIX. 
			tmpTabPage.SuspendLayout();
			tmpTabPage.Controls.Add(tmpRichTextBox); // This throws a NullReferenceException?? 
			tmpTabPage.ResumeLayout();
			tmpRichTextBox.Parent = tmpTabPage;
			tmpRichTextBox.WordWrap = tmpRichTextBox.DetectUrls = false;
			tmpRichTextBox.Font = new Font("Consolas", 7.8f);
			tmpRichTextBox.Dock = DockStyle.Fill;
			tmpRichTextBox.BringToFront();
			//tmpTabPage.Controls.Add(tmpRichTextBox);
			tabControl1.TabPages.Add(tmpTabPage); 
