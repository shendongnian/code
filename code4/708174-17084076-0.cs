    customLookUpEdit1.AllowClosePopup = false;
    customLookUpEdit1.ShowPopup();
    //...
    
    class CustomLookUpEdit : DevExpress.XtraEditors.LookUpEdit {
        public CustomLookUpEdit() {
            AllowClosePopup = true;
        }
        public bool AllowClosePopup {
            get;
            set;
        }
        protected override void ClosePopup(DevExpress.XtraEditors.PopupCloseMode closeMode) {
            if(!AllowClosePopup) return; // this line did the trick
            base.ClosePopup(closeMode);
        }
    }
