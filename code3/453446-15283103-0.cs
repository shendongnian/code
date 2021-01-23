        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            Control TheControl = e.AssociatedControl;
            cls_Global.gf_MDIForm.DisplayMsg(this.toolTip1.GetToolTip(TheControl) + "");
        }
