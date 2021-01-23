    ReportRootEntityViewModel result = GetReportRootNode(Convert.ToInt32(data[0]), reportRoot.Children);
                if (result != null)
                {
                  if (_previousSelectedReportRoots != null)
                  {
                    _previousSelectedReportRoots.Parent.Parent.IsExpanded = false;
                    _previousSelectedReportRoots.Parent.IsExpanded = false;
                    _previousSelectedReportRoots.IsExpanded = false;
    
                    _previousSelectedReportRoots.IsSelected = false;
                  }
    
                  result.Parent.Parent.IsExpanded = true;
                  result.Parent.IsExpanded = true;
                  result.IsExpanded = true;
    
                  result.IsSelected = true;              
                  SelectedReportRoot = result;
                  
                  SelectedReportRootDisplayName = data[1];
                 DisplayLabel = "Display Name :";
                  _previousSelectedReportRoots = SelectedReportRoot;
                  return;
                }  
