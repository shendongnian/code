    void panelKalendar_Paint(object sender, PaintEventArgs e)
    {
      Debug.WriteLine("panelKalendar_Paint");
      if (_viewType == ViewType.Week)
      {
        btnNext.Show();
        btnPrev.Show();
        lblMonth.Show();
        panelKalendar.Size = new Size(SIRKA_KALENDARE_WEEK, VYSKA_KALENDAREBEZPANELU_WEEK);
        //...
      }
      //...
    }
