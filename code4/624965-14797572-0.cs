    public void addRow(Control newRow) {
      if (this.table.InvokeRequired) {
        this.table.Invoke(new MethodInvoker(addRow), new object[]{ newRow });
      } else {
        this.table.Controls.Add(newRow);
        this.table.Controls.SetChildIndex(newRow, this.table.Controls.Count);
      }
    }
