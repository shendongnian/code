    class MyControl : Control
    {
        private Font segoe7Font = new Font(...);
    
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                segoe7Font.Dispose();
            base.Dispose(disposing);
        }
    }
