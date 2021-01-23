    public class CTabControl:TabControl
        {
            protected override void OnControlRemoved(ControlEventArgs e)
            {
                TabPage tp = e.Control as TabPage; // reference to tab page before it gets removed
                base.OnControlRemoved(e);// gets removed here
            }
        }
