     protected override void OnMouseEnter(EventArgs e)
     {
         this.Animate(1);
         base.OnMouseEnter(e);
     }
     protected override void OnMouseLeave(EventArgs e)
     {
         this.Animate(-1);
         base.OnMouseEnter(e);
     }
