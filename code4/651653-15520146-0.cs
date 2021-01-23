    void SaveCheckedPermissions(int _JobID, System.Windows.Forms.TreeNode RootNode)
    {
        using (WFMDBEntities _DBContext = new WFMDBEntities())
        {
            tbl_JobPermission _JopPermissionHelperVar;
            foreach (System.Windows.Forms.TreeNode aNode in RootNode.Nodes)
            {
                if (aNode.Checked == true)
                {
                    int _tempJobPermID;
                    int.TryParse(aNode.Name, out _tempJobPermID);
                    _JopPermissionHelperVar = new tbl_JobPermission();
                    _JopPermissionHelperVar.Tbljob = _JobID;
                    if (aNode.Name.Contains('_'))
                    {
                        int _tempSpecialJobPermID;
                        int.TryParse(aNode.Parent.Name, out _tempSpecialJobPermID);
                        if (_JobPermissions.Where(x => x.TblPremition == _tempSpecialJobPermID).FirstOrDefault() != null)
                        {
                            _JobPermissions.Where(x => x.TblPremition == _tempSpecialJobPermID).FirstOrDefault().TblPremition = _tempSpecialJobPermID;
                            if (aNode.Name.ToLower().Contains("add"))
                            {
                                _JobPermissions.Where(x => x.TblPremition == _tempSpecialJobPermID).FirstOrDefault().AllowNew = true;
                            }
                            else if (aNode.Name.ToLower().Contains("update"))
                            {
                                _JobPermissions.Where(x => x.TblPremition == _tempSpecialJobPermID).FirstOrDefault().AllowUpdate = true;
                            }
                            else if (aNode.Name.ToLower().Contains("delete"))
                            {
                                _JobPermissions.Where(x => x.TblPremition == _tempSpecialJobPermID).FirstOrDefault().AllowDelete = true;
                            }
                        }
                    }
                    else
                    {
                        if (_JobPermissions.Where(x => x.TblPremition == _tempJobPermID).FirstOrDefault() == null)
                        {
                            _JopPermissionHelperVar.TblPremition = _tempJobPermID;
                        }
                    }
                    if (_JobPermissions.Where(x => x.TblPremition == _JopPermissionHelperVar.TblPremition && x.Tbljob == _JopPermissionHelperVar.Tbljob).ToList().Count < 1)
                    {
                        _JobPermissions.Add(_JopPermissionHelperVar);
                    }
                }
                SaveCheckedPermissions(_JobID, aNode);
            }
        }
    }
