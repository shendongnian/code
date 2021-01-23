    public virtual string SelectedValue
    {
        get { ... }
        set
        {
            if (this.Items.Count != 0)
            {
                if (value == null || (base.DesignMode && value.Length == 0))
                {
                            this.ClearSelection();
                    return;
                }
                ListItem listItem = this.Items.FindByValue(value);
    /********** Checks IsPostBack here **********/
                bool flag = this.Page != null &&
                            this.Page.IsPostBack &&
                            this._stateLoaded;
                if (flag && listItem == null)
                {
                    throw new ArgumentOutOfRangeException("value",
                        SR.GetString("ListControl_SelectionOutOfRange", new object[]
                            {
                                this.ID,
                                "SelectedValue"
                            }));
                }
                if (listItem != null)
                {
                    this.ClearSelection();
                    listItem.Selected = true;
                }
            }
            this.cachedSelectedValue = value;
        }
    }
