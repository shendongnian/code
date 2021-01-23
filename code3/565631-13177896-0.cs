    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    public sealed class CustomToolStripMenuItem : ToolStripMenuItem
    {
        public CustomToolStripMenuItem()
        {
            DisplayStyle = ToolStripItemDisplayStyle.Text;
            BackColor = Color.LightSteelBlue;
            ForeColor = Color.MidnightBlue;
            Font = new Font(Font, FontStyle.Bold);
           // Or other options to your liking
         }
    }
