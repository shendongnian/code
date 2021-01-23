        int i = 1;
        for (int a = 0; a < SPItems.Count;)
        {
            WrapPanel pnl = UIHelper.FindChild<WrapPanel>(this, "SubItems");
            Button btn = UIHelper.FindChild<Button>(pnl, "SubItem" + i);
            TextBlock tb = UIHelper.FindChild<TextBlock>(btn, "SubItem" + i + "txt");
            btn.Visibility = Visibility.Visible;
            tb.Text = SPItems[a];
            a++;
            i++;
        }
