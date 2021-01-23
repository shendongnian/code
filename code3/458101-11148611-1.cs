    Sub DebugServerAndClientWithDelay()
        DTE.Debugger.Go(False)
        System.Threading.Thread.Sleep(2000)
        DTE.Windows.Item(Constants.vsWindowKindSolutionExplorer).Activate()
        DTE.ActiveWindow.Object.GetItem("SolutionName\ClientProjectName").Select(vsUISelectionType.vsUISelectionTypeSelect)
        DTE.ExecuteCommand("ClassViewContextMenus.ClassViewProject.Debug.Startnewinstance")
    End Sub
