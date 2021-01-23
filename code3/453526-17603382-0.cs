    <Designer(GetType(LocalizerDesigner))>
    <DesignerSerializer(GetType(LocalizerSerializer), GetType(CodeDomSerializer))>
    Public Class Localizer
        Inherits Component
    
        Public Sub GetResourceManager(type As Type, ByRef manager As ComponentResourceManager)
            ' Replace resource manager w/ new one.
        End Sub
    
    End Class
    
    Public Class LocalizerSerializer
        Inherits CodeDomSerializer
    
        Public Overrides Function Deserialize(manager As IDesignerSerializationManager, codeObject As Object) As Object
            Dim baseSerializer As CodeDomSerializer = DirectCast(manager.GetSerializer(GetType(Component), GetType(CodeDomSerializer)), CodeDomSerializer)
            Return baseSerializer.Deserialize(manager, codeObject)
        End Function
    
        Public Overrides Function Serialize(manager As IDesignerSerializationManager, value As Object) As Object
            Dim baseSerializer As CodeDomSerializer = DirectCast(manager.GetSerializer(GetType(Component), GetType(CodeDomSerializer)), CodeDomSerializer)
    
            Dim codeObject As Object = baseSerializer.Serialize(manager, value)
    
            Dim statementCollection As CodeStatementCollection = TryCast(codeObject, CodeStatementCollection)
    
            If statementCollection IsNot Nothing Then
                Dim formClassTypeDeclaration As CodeTypeDeclaration = DirectCast(manager.GetService(GetType(CodeTypeDeclaration)), CodeTypeDeclaration)
                Dim typeofFormExpression As New CodeTypeOfExpression(formClassTypeDeclaration.Name)
    
                Dim outResourcesExpression As New CodeDirectionExpression(FieldDirection.Out, New CodeVariableReferenceExpression("resources"))
                Dim getResourceManagerExpression As New CodeMethodInvokeExpression(MyBase.SerializeToExpression(manager, value), "GetResourceManager",
                                                                         {typeofFormExpression, outResourcesExpression})
    
                statementCollection.Add(New CodeExpressionStatement(getResourceManagerExpression))
            End If
            Return codeObject
        End Function
    End Class
    
    Public Class LocalizerDesigner
        Inherits ComponentDesigner
    
        Public Overrides Sub Initialize(component As IComponent)
            MyBase.Initialize(component)
            Dim designerHost As IDesignerHost = TryCast(GetService(GetType(IDesignerHost)), IDesignerHost)
            If designerHost Is Nothing Then
                Return
            End If
    
            Dim innerListProperty As Reflection.PropertyInfo = designerHost.Container.Components.GetType().GetProperty("InnerList", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.FlattenHierarchy)
            Dim innerList As ArrayList = TryCast(innerListProperty.GetValue(designerHost.Container.Components, Nothing), ArrayList)
    
            If innerList Is Nothing OrElse innerList.IndexOf(component) <= 1 Then
                Return
            End If
    
            innerList.Remove(component)
            innerList.Insert(0, component)
        End Sub
    End Class
