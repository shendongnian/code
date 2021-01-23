    private void Item_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
        var s = sender as TextBlock;
        MessageBox.Show(d[s.Text]);
    }
