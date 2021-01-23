       lookup1.Popup+=new EventHandler(gridLookUpEdit1_Popup);
            
        protected void gridLookUpEdit1_Popup(object sender, EventArgs e)
        {
            this.lookup1.Properties.View.Columns[0].Visible =false;
        }
