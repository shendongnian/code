        private bool IsActive = false;
        
        private void dgbList_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (IsActive)
            {
                if (Do_I_NeedTo_Cancel)
                  e.Cancel = true;
            }
        }
        private void dgList_Leave(object sender, EventArgs e)
        {
            IsActive = false;
        }
        private void dgList_Enter(object sender, EventArgs e)
        {
            IsActive = true;
        }
