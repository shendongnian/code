    public class CustomTableLayoutPanel : TableLayoutPanel
    {
        public CustomTableLayoutPanel()
        {
            RowStyles.Clear();
            RowStyles.Add(new RowStyle(SizeType.Percent, 0.25F));
            RowStyles.Add(new RowStyle(SizeType.Percent, 0.75F));
            BackColor = Color.Beige;
        }
    }
