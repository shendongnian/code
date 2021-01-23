	public void OnConnection(object application, ext_ConnectMode connectMode, 
                             object addInInst, ref Array custom)
	{
		_applicationObject = (DTE2)application;
		_addInInstance = (AddIn)addInInst;
        if (_de == null)
        {
            _de = _applicationObject.Events.get_DocumentEvents(null);
        }
        //Handle document saved event
        if (_deSavedEvent == null)
        {
            _deSavedEvent = new _dispDocumentEvents_DocumentSavedEventHandler(
                                                   DocumentEvents_DocumentSaved);
            _de.DocumentSaved += _deSavedEvent;
        }
    }
    private static DocumentEvents _de = null;
    private static _dispDocumentEvents_DocumentSavedEventHandler _deSavedEvent =null;
    private void DocumentEvents_DocumentSaved(EnvDTE.Document document)
    {
        System.Windows.Forms.MessageBox.Show("Replace this with code to run .bat");
    }
