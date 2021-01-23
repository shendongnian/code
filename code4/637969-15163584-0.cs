    [ProvideAutoLoad(Microsoft.VisualStudio.Shell.Interop.UIContextGuids.NoSolution)]
    [ProvideAutoLoad(VSConstants.UICONTEXT.SolutionExists_string)]
     protected override void Initialize()
        {
           //DTE gets called
            var dte = (EnvDTE.DTE)GetService(typeof(EnvDTE.DTE));
            _EventsObj = dte.Events.DTEEvents;
            _EventsObj.OnStartupComplete += OnStartupComplete;
        }
            public void OnStartupComplete()
        {
            //This is the code to launch the dialog.
            EvaluationDialog EvalForm = new EvaluationDialog();
            EvalForm.ShowDialog();
        }
