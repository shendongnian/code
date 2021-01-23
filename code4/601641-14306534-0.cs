     private readonly BuildEvents _buildEvents;
     private readonly SelectionEvents _selectionEvents;
     private readonly DocumentEvents _documentEvents;
     public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
     {
         _applicationObject = (DTE2)application;
         _addInInstance = (AddIn)addInInst;
         _buildEvents = _applicationObject.Events.BuildEvents;
         _buildEvents.OnBuildBegin += BuildEvents_OnBuildBegin;
         _buildEvents.OnBuildDone += BuildEvents_OnBuildDone;
         _selectionEvents = _applicationObject.Events.SelectionEvents;
         _selectionEvents.OnChange += SelectionEvents_OnChange;
    
         _documentEvents = _applicationObject.Events.DocumentEvents;
         _documentEvents.DocumentOpened += DocumentEvents_DocumentOpened;
         _documentEvents.DocumentSaved += DocumentEvents_DocumentSaved;
     }
