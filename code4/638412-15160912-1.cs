        public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
        {
            _applicationObject = (DTE2)application;
            _addInInstance = (AddIn)addInInst;
            _events = _applicationObject.Events;
            _buildEvents = _events.BuildEvents;
            if (connectMode != ext_ConnectMode.ext_cm_UISetup && !buildEventConnected)
            {
                _buildEvents.OnBuildDone +=
                    new _dispBuildEvents_OnBuildDoneEventHandler(BuildEvents_OnBuildDone);
                buildEventConnected = true;
            }
        }
        private void BuildEvents_OnBuildDone(vsBuildScope Scope, vsBuildAction Action)
        {
            const string BUILD_OUTPUT_PANE_GUID = "{1BD8A850-02D1-11D1-BEE7-00A0C913D1F8}";
            TextDocument txtOutput = default(TextDocument);
            TextSelection txtSelection = default(TextSelection);
            Window vsWindow = default(Window);
            vsWindow = _applicationObject.Windows.Item(EnvDTE.Constants.vsWindowKindOutput);
            OutputWindow vsOutputWindow = default(OutputWindow);
            OutputWindowPane objBuildOutputWindowPane = default(OutputWindowPane);
            vsOutputWindow = (OutputWindow)vsWindow.Object;
            foreach (OutputWindowPane objOutputWindowPane in vsOutputWindow.OutputWindowPanes)
            {
                if (objOutputWindowPane.Guid.ToUpper() == BUILD_OUTPUT_PANE_GUID)
                {
                    objBuildOutputWindowPane = objOutputWindowPane;
                    break;
                }
            }
            txtOutput = objBuildOutputWindowPane.TextDocument;
            txtSelection = txtOutput.Selection;
            txtSelection.StartOfDocument(false);
            txtSelection.EndOfDocument(true);
            objBuildOutputWindowPane.OutputString(System.DateTime.Now.ToString());
            txtSelection = txtOutput.Selection;
            var solutionDir = System.IO.Path.GetDirectoryName(_applicationObject.Solution.FullName);
            System.IO.File.WriteAllText(solutionDir + "\\build_output.log", txtSelection.Text);
        }
        public void OnDisconnection(ext_DisconnectMode disconnectMode, ref Array custom)
        {
            if (buildEventConnected)
            {
                _buildEvents.OnBuildDone -= new _dispBuildEvents_OnBuildDoneEventHandler(BuildEvents_OnBuildDone);
                buildEventConnected = false;
            }
        }
