    public class MyMenuItem : MenuItem
    {
        public MyMenuItem()
        {
            OwnerDraw = true;
            
        }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            // Add paint logic here
        }
    }
