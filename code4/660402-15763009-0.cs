     public void FillSearch()
        {
            var playerList = dianaDB.TblPlayers.Where(p => p.Status == "Active" & p.CancellationStatus == "Active" & p.Version == "Active").Select(p => p);
            Panel pnlPlayer = new Panel();
            foreach (var pl in playerList)
            {
                pnlPlayer = new Panel();
                pnlPlayer.Size = new Size(153, 116);
                pnlPlayer.BorderStyle = BorderStyle.FixedSingle;
                pnlPlayer.Cursor = Cursors.Hand;
                pnlPlayer.Click += new EventHandler(pbx_Click);
                pnlPlayer.Tag = pl.Id;
            }
        }
        private void pbx_Click(object sender, EventArgs e)
        { 
             var panle = sender as Panel;
             if(panel!=null)
             {
               DlgSearchDetails newDlg = new DlgSearchDetails(panel.Tag);
               newDlg.ShowDialog();
             }
            
        }
