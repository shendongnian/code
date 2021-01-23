    void SelectionPageForAutomation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Key.Escape)
            {
                btn_Cancel.PerformClick();
            }
            else if(e.KeyChar == Key.Enter){
                btn_Okay.PerformClick();
            }
        }
