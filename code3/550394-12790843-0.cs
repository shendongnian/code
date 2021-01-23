    public class SearchControl : UserControl
    {
        protected override void OnValidating(CancelEventArgs e)
        {
            BaseForm frm = FindForm() as BaseForm;
            if (frm != null && frm.IsClosing)
            {
                e.Cancel = true;
                //TODO Cancel validation event on all objects
            }
        }
    }
