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
            //or you could do it like this
            //if(e.Index == this.SelectedIndex)
            //{
            //}
            ...
            
        }
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            base.Invalidate();
        }
