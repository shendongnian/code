    int i = 1;
    int a = 0;
    foreach (string spi in SPItems)
        {
            WrapPanel pnl = UIHelper.FindChild<WrapPanel>(this, "SubItems");
            Button btn = UIHelper.FindChild<Button>(pnl, "SubItem" + i);
            TextBlock tb = UIHelper.FindChild<TextBlock>(btn, "SubItem" + i + "txt");
            btn.Visibility = Visibility.Visible;
            tb.Text = SPItems[a];
            a++;
            i++;
        }
