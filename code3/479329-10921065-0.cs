        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.State == DrawItemState.Selected)
            {
                ...
            }
            else
            {
                ...
            }
            ...
        }
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            base.Invalidate();
        }
