    public class MyLabel: Label
    {
        public string ID { get; set; }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (this.DesignMode && string.IsNullOrEmpty(this.ID))
            {
                this.ID = Guid.NewGuid().ToString();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.Text = this.ID;
        }
    }
