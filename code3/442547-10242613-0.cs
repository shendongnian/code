		public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
		{
			_applicationObject = (DTE2)application;
			_addInInstance = (AddIn)addInInst;
            // Hook save changes event
			_applicationObject.Events.DocumentEvents.DocumentSaved += DocumentEvents_DocumentSaved;
			
		}
