    For Each item As EnvDTE.Project In mApplicationObject.Solution.Projects
         If item.Globals Is Nothing AndAlso item.Object Is Nothing Then
            Console.WriteLine(item.Name + "  is currently unloaded!")
         End If
    Next
