        protected void btnGo_Click(object sender, EventArgs e)
        {
            Control p1t1 = ControlFinder.Find(pnl1, "pnl1_txt1");
            Control p1t2 = ControlFinder.Find(pnl1, "pnl1_txt2");
            Control p2t1 = ControlFinder.Find(pnl1, "pnl2_txt1");
            Control p2t2 = ControlFinder.Find(pnl1, "pnl2_txt2");
            Control p3t1 = ControlFinder.Find(pnl1, "pnl3_txt1");
            Control p3t2 = ControlFinder.Find(pnl1, "pnl3_txt2");
            Control doesntexist = ControlFinder.Find(pnl1, "asdasd");
            lblpnl1txt1.Text = p1t1 != null ? "Found: " + p1t1.ID : "Not found";
            lblpnl1txt2.Text = p1t2 != null ? "Found: " + p1t2.ID : "Not found";
            lblpnl2txt1.Text = p2t1 != null ? "Found: " + p2t1.ID : "Not found";
            lblpnl2txt2.Text = p2t2 != null ? "Found: " + p2t2.ID : "Not found";
            lblpnl3txt1.Text = p3t1 != null ? "Found: " + p3t1.ID : "Not found";
            lblpnl3txt2.Text = p3t2 != null ? "Found: " + p3t2.ID : "Not found";
            lblUnknown.Text = doesntexist != null ? "Found: " + doesntexist.ID : "Not found";
        }
