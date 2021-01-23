    IQueryable<QueriesParameter> param = _service.GetParams(QKey);
    int i = 1; // btw whe you are iterating from index 1?
    foreach(var p in param)
    {
       OnPropertyChanged(paramLabelVisibility[i]);
       OnPropertyChanged(paramVisibility[i]);
       QueriesParameter qParam = p; // here
       m_LabelName = qParam.ParameterName;
       OnPropertyChanged(paramLabel[i]);
       i++;
    }    
