    public override void OnCancel () // called from on click event of cancel button
     {
     
     foreach (DatatoDelete dataGridViewRow in visitorHostsDataRowToDelete)
      {
      _hosts.Add (dataGridViewRow.VisitorHostRecord);
      }
     visitorHostsDataRowToDelete.Clear();
     _hosts.Sort ();
     this.visitorhostBindingSource.DataSource = null;
     this.visitorhostBindingSource.DataSource = _hosts;
     this.visitorHostsDataGridView.Refresh ();
          
     ClearModified (); //disable save and cancel buttons
     }
