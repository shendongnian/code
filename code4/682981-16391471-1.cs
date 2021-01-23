        protected void Page_Load(object sender, EventArgs e){
        this.PopulateRootLevel();
        }
        private void PopulateRootLevel()
        {
            DataTable _dataTable = this.GetDataTable(ApplicationConfig.ConnString, "sp_PopulateRootLevel", "parentID", String.Empty);
            this.PopulateNodes(_dataTable, this.HierarchyTreeView.Nodes);
        }
        private void PopulateSubLevel(String _parentID, TreeNode _parentNode)
        {
            DataTable _dataTable = this.GetDataTable(ApplicationConfig.ConnString, "sp_PopulateRootLevel", "parentID", _parentID);
            this.PopulateNodes(_dataTable, _parentNode.ChildNodes);
        }
        protected void HierarchyTreeView_TreeNodePopulate(object sender, TreeNodeEventArgs e)
        {
            PopulateSubLevel(e.Node.Value.ToString(), e.Node);
        }
        private void PopulateNodes(DataTable _dataTable, TreeNodeCollection _nodes)
        {
            foreach (DataRow _dataRow in _dataTable.Rows)
            {
                TreeNode _treeNode = new TreeNode();
                _treeNode.Text = _dataRow["EmpName"].ToString();
                _treeNode.Value = _dataRow["EmpNumb"].ToString();
                
                if (_dataRow["FgActive"].ToString() == "Y")
                    _nodes.Add(_treeNode);
                
                _treeNode.PopulateOnDemand = ((int)(_dataRow["ChildNodeCount"]) > 0);
            }
        }
    public DataTable GetDataTable(String _prmConnString, String _prmStoreProcedure, String _prmField, String _prmValue)
        {
            DataTable _result = new DataTable();
            string[] _field = _prmField.Split('|');
            string[] _value = _prmValue.Split('|');
            try
            {
                SqlConnection _conn = new SqlConnection(_prmConnString);
                SqlCommand _cmd = new SqlCommand();
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.Parameters.Clear();
                _cmd.Connection = _conn;
                _cmd.CommandTimeout = 180;
                _cmd.CommandText = _prmStoreProcedure;
                for (int i = 0; i < _field.Count(); i++)
                    _cmd.Parameters.AddWithValue("@" + _field[i], _value[i]);
                SqlDataAdapter _da = new SqlDataAdapter();
                _da.SelectCommand = _cmd;
                _da.Fill(_result);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }
