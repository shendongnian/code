    private void ScorePanel_Scroll(object sender, ScrollEventArgs e)
    {
        var senderPanel = sender as Panel;
        if (senderPanel == null)
        {
            // Might want to print to debug or mbox something, because this shouldn't happen.
            return;
        }
        var otherPanel = senderPanel == Panel1 ? Panel2 : Panel1;
        otherPanel.VerticalScroll.Value = senderPanel.VerticalScroll.Value;
    }
