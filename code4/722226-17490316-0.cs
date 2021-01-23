        private void btnSrchInterests_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var results = from c in db.CaseSelectors
                          join i in db.Interests on c.CaseNumberKey equals i.CaseNumberKey
                          where i.First.Contains(txtFirst.Text) && i.Last.Contains(txtLast.Text)
                          select c.CaseNumberKey;
            caseSelectorBindingSource.Filter = ("CaseNumberKey =" + String.Join(" OR CaseNumber = ", results.ToList()) );
        }
