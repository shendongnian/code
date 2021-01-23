    public class GenericDocumentViewer : DocumentViewer
    {
        public event Action<object> MasterPageNumberChanged;
        protected override void OnMasterPageNumberChanged()
        {
            base.OnMasterPageNumberChanged();
            if (MasterPageNumberChanged != null)
                MasterPageNumberChanged(this);
        }
    }
