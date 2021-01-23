    Imports System
    Imports EnvDTE
    Imports EnvDTE80
    Imports EnvDTE90
    Imports EnvDTE90a
    Imports EnvDTE100
    Imports System.Diagnostics
    Imports System.IO
 
    Public Module Templates
        ' Get the active class (in this case will be the entity that you have just created)
        Dim entity As String = DTE.ActiveDocument.Name.Replace(".cs", "")
        Dim projects As Projects = DTE.Solution.Projects
        ' Project where are the template classes   
        Dim projectTemplates As Project = DTE.ActiveDocument.ProjectItem.ContainingProject
        Sub CreateCRUD()
            ' Exemple of creating DAO Class
            CreateClass("NamespaceWhereAreYouProject.Repositorio\ NamespaceWhereAreYouProject.Repositorio.csproj", _
                        "DAL", _
                        " NamespaceWhereAreYouProject.Repository.DAL", _
                        "DAO" + entity, _
                        "DAOTemplate.cs")
        End Sub
        Private Sub CreateClass(ByVal currentProject As String, _
                                     ByVal currentFolder As String, _
                                     ByVal currentNamespace As String, _
                                     ByVal currentClass As String, _
                                     ByVal currentTemplate As String)
            ' Loading attributes
            Dim project As Project = projects.Item(currentProject)
            Dim folder As ProjectItem = project.ProjectItems.Item(currentFolder)
            Dim currentTemplatePath As String = projectTemplates.ProjectItems.Item("Templates") _
                .ProjectItems.Item(currentTemplate).Properties.Item("FullPath").Value
            Dim newClassPath As String = folder.Properties.Item("FullPath").Value + currentClass + ".cs"
            ' Creating class
            folder.ProjectItems.AddFromTemplate(currentTemplatePath, currentClass + ".cs")
            Dim newText As String = File.ReadAllText(newClassPath) _
                .Replace("#class#", currentClass) _
                .Replace("#namespace#", currentNamespace) _
                .Replace("#entity#", entity)
            File.WriteAllText(newClassPath, newText)
        End Sub
    End Module
