    Public Class CheckBoxTemplate
        Implements ITemplate   
    
        Public Sub InstantiateIn(ByVal container As System.Web.UI.Control) Implements System.Web.UI.ITemplate.InstantiateIn
            Dim cb As CheckBox = New CheckBox()
            cb.ID = "someId"
            cb.AutoPostBack = True
    
            container.Controls.Add(cb)
    
    
        End Sub
    End Class
