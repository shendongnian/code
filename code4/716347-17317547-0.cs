    public override object Clone()
    {
        DataGridViewRow row;
        Type type = base.GetType();
        if (type == rowType)
        {
            row = new DataGridViewRow();
        }
        else
        {
            row = (DataGridViewRow) Activator.CreateInstance(type);
        }
        if (row != null)
        {
            base.CloneInternal(row);
            if (this.HasErrorText)
            {
                row.ErrorText = this.ErrorTextInternal;
            }
            if (base.HasHeaderCell)
            {
                row.HeaderCell = (DataGridViewRowHeaderCell) this.HeaderCell.Clone();
            }
            row.CloneCells(this);
        }
        return row;
    }
