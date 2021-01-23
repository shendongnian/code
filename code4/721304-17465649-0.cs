    Dim project As Project
    project = DTE.ActiveSolutionProjects(0)
    ListProjAux(project.ProjectItems(), 0)
    Sub ListProjAux(ByVal projectItems As EnvDTE.ProjectItems, ByVal level As Integer)
      Dim projectItem As EnvDTE.ProjectItem
      For Each projectItem In projectItems
        projectItems2 = projectItem.ProjectItems
           ListProjAux(projectItems2, level + 1)
      Next
    End Sub
