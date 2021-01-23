            protected override void OnDataSourceChanged(EventArgs e)
        {
            if ((this.Sorted && (this.DataSource != null)) && base.Created)
            {
                this.DataSource = null;
                throw new InvalidOperationException(System.Windows.Forms.SR.GetString("ComboBoxDataSourceWithSort"));
            }
            ...
            ...
        }
