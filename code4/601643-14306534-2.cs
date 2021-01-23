     private readonly BuildEvents _buildEvents;
     private readonly SelectionEvents _selectionEvents;
     private readonly DocumentEvents _documentEvents;
     private readonly Events _events;
     public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
     {
         _applicationObject = (DTE2)application;
         _addInInstance = (AddIn)addInInst;
         _events = _applicationObject.Events;
         
         _buildEvents = _events.BuildEvents;
         _buildEvents.OnBuildBegin += BuildEvents_OnBuildBegin;
         _buildEvents.OnBuildDone += BuildEvents_OnBuildDone;
         _selectionEvents = _events.SelectionEvents;
         _selectionEvents.OnChange += SelectionEvents_OnChange;
    
         _documentEvents = _events.DocumentEvents;
         _documentEvents.DocumentOpened += DocumentEvents_DocumentOpened;
         _documentEvents.DocumentSaved += DocumentEvents_DocumentSaved;
     }
