    public class CustomListView : BetterListView
    {
        public void SynchronizeScroll(BetterListView listView)
        {
            VScrollBar.Value = listView.VScrollProperties.Value;
        }
    }
