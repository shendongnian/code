     void frmMain_CheckedChanged(object sender, EventArgs e)
            {
                CheckBox chk = (CheckBox)sender;
                if (chk != null && chk.Tag != null && !string.IsNullOrEmpty(chk.Tag.ToString()))
                {
                    NodeManager.UpdateNodeActive(chk.Tag.ToString(), chk.Checked);
    
                    _isCheckUncheckQueued = true;
                    ProcessQueuedNodeList();
                }
            }
