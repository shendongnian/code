    public DataGridView EditingControlDataGridView
    {
        get { return this.mEditingControlDataGridView; }
        set
        {
            if (this.mEditingControlDataGridView != null)
            {
                this.mEditingControlDataGridView.Disposed -= this.EditingControlDataGridView_Disposed;
                Application.RemoveMessageFilter(this.mCurrentMessageFilter);
                this.mCurrentMessageFilter = null;
            }
            this.mEditingControlDataGridView = value;
            if (this.mEditingControlDataGridView != null)
            {
                this.mCurrentMessageFilter = new RouteKeyDownMessageFilter(this, Keys.Return);
                Application.AddMessageFilter(this.mCurrentMessageFilter);
                this.mEditingControlDataGridView.Disposed += this.EditingControlDataGridView_Disposed;
            }
        }
    }
    private void EditingControlDataGridView_Disposed(object sender, EventArgs e)
    {
        if (this.mCurrentMessageFilter != null)
        {
            Application.RemoveMessageFilter(this.mCurrentMessageFilter);
        }
    }
