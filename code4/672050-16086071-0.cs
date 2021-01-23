    public class CustomControl : ContainerControl
    {
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            if (this.Parent != null && !(this.Parent is Form))
            {
                this.Parent.Controls.Remove(this);
                throw new ArgumentException("CustomControl can only be a child of Form");
            }
        }
    }
