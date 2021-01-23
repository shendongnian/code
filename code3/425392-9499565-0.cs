        /// <summary>
        /// Which row is currently being rendered
        /// </summary>
        protected int RowIndex { get; set; }
    
        protected override void OnLoad(EventArgs e)
        {      
          this.RowIndex = 0;
          this.DataGrid.DataSource = new string[] { "a", "b", "c" }; // bind the contents
          this.DataGrid.DataBind();      
        }
    
        /// <summary>
        /// When an item is bound
        /// </summary>
        protected void OnItemDataBound(object sender, DataGridItemEventArgs e)
        {
          this.RowIndex++;
          Label label = e.Item.FindControl("RowLabel") as Label;
          if (label != null)
          {
            label.Text = this.RowIndex.ToString();
          }
        }
