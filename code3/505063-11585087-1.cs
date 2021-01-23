    private void doNew()
		{
            try
            {
                this.m_bDialogOpen = true;
                MergeLetterDocsDO clnt = new MergeLetterDocsDO(7);
                NewMergeLetterTitle title = new NewMergeLetterTitle("New Merge Letter", 7);
                DialogResult dr = title.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    Form1 frm = new Form1(Simple.Form1.DocumentTypes.MERGE_LETTER, Simple.Form1.OperationModes.DESIGN_TIME, null);
                    frm.ShowDialog(this);
                    byte[] bb = frm.InternalFormatDocument;
                    byte[] rtfbb = frm.RtfFormatDocument;
                    clnt.SaveNewMergeTemplate(bb, rtfbb, bb.Length, rtfbb.Length, title.MergeLetterTitle);
                }
                this.m_bDialogOpen = false;
                this.Populate();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
		}O
