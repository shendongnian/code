    void timer_Tick(object sender, EventArgs e) {
      flowPanel.VerticalScroll.Value += 1;
      if (flowPanel.VerticalScroll.Value + flowPanel.VerticalScroll.LargeChange > 
                                           flowPanel.VerticalScroll.Maximum) {
        ((Timer)sender).Enabled = false;
      }
    }
