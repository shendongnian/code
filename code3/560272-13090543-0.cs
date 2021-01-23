    this.Trace.Write("aspx.page", "Begin PreInit");
    this.PerformPreInit();
    this.Trace.Write("aspx.page", "End PreInit");
    this.Trace.Write("aspx.page", "Begin Init");
    this.InitRecursive((Control) null);
    this.Trace.Write("aspx.page", "End Init");
    this.Trace.Write("aspx.page", "Begin InitComplete");
    this.OnInitComplete(EventArgs.Empty);
    this.Trace.Write("aspx.page", "End InitComplete");
    
    if (this.IsPostBack)
    {
    	this.Trace.Write("aspx.page", "Begin LoadState");
    	this.LoadAllState();
    	this.Trace.Write("aspx.page", "End LoadState");
    	this.Trace.Write("aspx.page", "Begin ProcessPostData");
    	this.ProcessPostData(this._requestValueCollection, true);
    	this.Trace.Write("aspx.page", "End ProcessPostData");  
    }
    
    this.Trace.Write("aspx.page", "Begin PreLoad");
    this.OnPreLoad(EventArgs.Empty);
    this.Trace.Write("aspx.page", "End PreLoad");
    this.Trace.Write("aspx.page", "Begin Load");
    this.LoadRecursive();
    this.Trace.Write("aspx.page", "End Load");
    
    if (this.IsPostBack)
    {
    	this.Trace.Write("aspx.page", "Begin ProcessPostData Second Try");
    	this.ProcessPostData(this._leftoverPostData, false);
    	this.Trace.Write("aspx.page", "End ProcessPostData Second Try");
    	this.Trace.Write("aspx.page", "Begin Raise ChangedEvents");
    	this.RaiseChangedEvents();
    	this.Trace.Write("aspx.page", "End Raise ChangedEvents");
    	this.Trace.Write("aspx.page", "Begin Raise PostBackEvent");
    	this.RaisePostBackEvent(this._requestValueCollection);
    	this.Trace.Write("aspx.page", "End Raise PostBackEvent");
    }
    
    this.Trace.Write("aspx.page", "Begin LoadComplete");
    this.OnLoadComplete(EventArgs.Empty);
    this.Trace.Write("aspx.page", "End LoadComplete");
    
    if (this.IsPostBack && this.IsCallback)
    	this.PrepareCallback(callbackControlID);
    else if (!this.IsCrossPagePostBack)
    {
    	this.Trace.Write("aspx.page", "Begin PreRender");
    	this.PreRenderRecursiveInternal();
    	this.Trace.Write("aspx.page", "End PreRender");
    }
    
    ...
    
    if (this.IsCallback)
    {
    	this.RenderCallback();
    }
    else
    {
    	if (this.IsCrossPagePostBack)
    		return;
    		
    	this.Trace.Write("aspx.page", "Begin PreRenderComplete");
    	this.PerformPreRenderComplete();
    	this.Trace.Write("aspx.page", "End PreRenderComplete");
    	this.BuildPageProfileTree(this.EnableViewState);
    	this.Trace.Write("aspx.page", "Begin SaveState");
    	this.SaveAllState();
    	this.Trace.Write("aspx.page", "End SaveState");
    	this.Trace.Write("aspx.page", "Begin SaveStateComplete");
    	this.OnSaveStateComplete(EventArgs.Empty);
    	this.Trace.Write("aspx.page", "End SaveStateComplete");
    	this.Trace.Write("aspx.page", "Begin Render");
    
    	if (exportedWebPartID != null)
    		this.ExportWebPart(exportedWebPartID);
    	else
    		this.RenderControl(this.CreateHtmlTextWriter(this.Response.Output));
    		
    	this.Trace.Write("aspx.page", "End Render");
    	this.CheckRemainingAsyncTasks(false);
    }
