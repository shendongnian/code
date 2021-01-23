        List<DisplayBindItem> cust = (from x in _db.m01_customers
                where x.m01_customer_type == CustomerType.Member.GetHashCode()
                select new DisplayBindItem
                {
                    Key = x.m01_id.ToString(),
                    Value = x.m01_customer_name
                }).ToList();
        cmbApprover1.BindingContext = new BindingContext();
        cmbApprover1.DataSource = cust;
        cmbApprover1.DisplayMember = "Value";
        cmbApprover1.ValueMember = "Key";
        //This does the trick :)
        cmbApprover2.BindingContext = new BindingContext();
        cmbApprover2.DataSource = cust ;
        cmbApprover2.DisplayMember = "Value";
        cmbApprover2.ValueMember = "Key";
