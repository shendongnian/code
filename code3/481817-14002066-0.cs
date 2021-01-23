            InitializeComponent();
            // special setup for enum column
            DataGridViewComboBoxColumn stateColumn = dgLedger.Columns[0] as DataGridViewComboBoxColumn;
            if (stateColumn != null)
            {
                stateColumn.DataSource = Enum.GetValues(typeof(TransactionState));
            }
            _ledger = new BindingList<LedgerItem>();
            dgLedger.DataSource = _ledger;
