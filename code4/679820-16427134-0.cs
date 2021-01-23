        private void setOrderGridView()
        {
            BindingSource orderSrc = new BindingSource(logic.GetOrderDetailsDS(FrmOrder.currentOrderID), "tblOrders");
            dgvOrdrdtls.DataSource = orderSrc;
            var src = logic.GetProductTable();
            BindingSource detailSrc = new BindingSource(orderSrc, "orderdetails");
            dgvLines.DataSource = detailSrc;
            DataGridViewComboBoxColumn pr = new DataGridViewComboBoxColumn();
            pr.HeaderText = "Product";
            pr.Name = "product";
            pr.DataSource = src;
            pr.ValueMember = "pdctId";
            pr.DisplayMember = "prdctDsc";
            pr.DataPropertyName = "ordrPrdctid";
            
            dgvLines.Columns.Add(pr);
           
        }
