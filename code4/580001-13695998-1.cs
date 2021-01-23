            private void PopulatePhoneNumbers(clsContacts contacts)
        {
            //Create the 1st column as a textbox for the Phone Number
            DataGridViewTextBoxColumn tb = new DataGridViewTextBoxColumn();
            tb.Name = "PhoneNumber";
            tb.DataPropertyName = "PhoneNumber"; //This is the name of the PhoneNumber object Property for Phone Number
            //Create  2nd column as combobox for PhoneType
            DataGridViewComboBoxColumn cb = new DataGridViewComboBoxColumn();
            cb.Name = "PhoneTypes";
            cb.DataPropertyName = "PhoneTypesFK"; //This is the name of the PhoneNumber object Property for Phone Type
            //Bind the cb to the table
            string sqlQuery = "SELECT PT_PhoneTypes_PK, PT_Description " +
                              "FROM [Pensions].[dbo].[PhoneTypes] ";
            DataTable dtPhoneTypes = SQLCommon.Instance.SQLSelect(sqlQuery);
            cb.DataSource = dtPhoneTypes;
            cb.ValueMember = dtPhoneTypes.Columns["PT_PhoneTypes_PK"].ColumnName;
            cb.DisplayMember = dtPhoneTypes.Columns["PT_Description"].ColumnName;
            uxContactPhoneNumbersGrd.Columns.Add(tb);
            uxContactPhoneNumbersGrd.Columns.Add(cb);
            uxContactPhoneNumbersGrd.AutoGenerateColumns = false;
            if (contacts.PhoneNumbers != null)
            {
                //Show how many phone numbers
                uxContactPhoneNumbersLbl.Text = string.Format("Phone Numbers ({0})", contacts.PhoneNumbers.Count);
                uxContactPhoneNumbersLbl.Visible = true;
                //Fill Grid
                uxContactPhoneNumbersGrd.DataSource = contacts.PhoneNumbers;
                //Hide non-required columns/rows
                uxContactPhoneNumbersGrd.RowHeadersVisible = false;
            }
            //Adjust text column size and auto wrap
            uxContactPhoneNumbersGrd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            uxContactPhoneNumbersGrd.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
       }
    
