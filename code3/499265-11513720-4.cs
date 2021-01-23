    Public Module Main
        Public Sub Main()
            Dim FormSpecAsText As String = ...  read XML form def from file
            Dim Outfile As String = ... output file is in my project 
    
            ' Setup for Winforms platform
            Dim dsg As New DynamicScreenGenerator
            Dim ListOfControls As New PanelObjectList
            ControlFactoryLocator.AddService( _
                New PanelObjectFactoryWinFormBasicControls)
            ControlFactoryLocator.AddService(_
                New PanelObjectFactoryWinFormAppSpecificCtls)
            ControlFactoryLocator.AddService(_
                New PanelObjectFactoryWinFormFormEditorCtls)
    
            ' Deserialize FormSpecAsText into a flat list of Controls
            ListOfControls.AddRange( _
                dsg.BuildDSGLists(FormSpecAsText, ListOfControls).ToArray)
    
            ' setup for serialization to Code
            Dim hsm As New Host.HostSurfaceManager
            Dim hc As Host.HostControl = _
              hsm.GetNewHost(GetType(Form), Host.LoaderType.CodeDomDesignerLoader)
    
            ' Get main form that was created via GetNewHost, autosize it
            Dim HostUserControl = _
                CType(hc.DesignerHost.Container.Components(0), Form)
    
            ' Parent them properly, and add to host (top lvl ctls have parent="")
            SetChildren(HostUserControl, "", dsg, hc.DesignerHost.Container)
            HostUserControl.AutoSize = True
    
            ' write serialized version to a file in my project
            IO.File.WriteAllText(Outfile, _
              CType(hc.HostSurface.Loader, Loader.CodeDomHostLoader).GetCode("VB"))
        End Sub
    
        Sub SetChildren(ByVal Parent As Control, ByVal ParentName As String, _
               ByVal dsg As DynamicScreenGenerator, ByVal ctr As IContainer)
            For Each PO In (From p In dsg.POList Where p.Parent = ParentName)
                Dim child = CType(dsg.CTLList(PO), Control)
                ctr.Add(child, PO.Name) ' seem to have to add to container while 
                 '  parenting them or .Controls isn't serialized and form is blank.
                Parent.Controls.Add(child)
                SetChildren(child, PO.Name, dsg, ctr)
            Next
        End Sub
    End Module
