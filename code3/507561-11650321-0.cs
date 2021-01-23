    private void comboBoxDb_DrawItem(object sender, DrawItemEventArgs e) 
    {
        var combo = sender as ComboBox;
        if((e.State & DrawItemState.Selected) == DrawItemState.Selected)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.BlueViolet), e.Bounds);
        }
        else
        {
            e.Graphics.FillRectangle(new SolidBrush(SystemColors.Window), e.Bounds);
        }
    
        e.Graphics.DrawString(combo.Items[e.Index].ToString(),
                                      e.Font,
                                      new SolidBrush(Color.Black),
                                      new Point(e.Bounds.X, e.Bounds.Y));
}
