    class CustomScrollBarPanel : System.Windows.Forms.Panel
    {
        protected override Point ScrollToControl(Control activeControl)
        {
            return this.AutoScrollPosition;
        }
    }
