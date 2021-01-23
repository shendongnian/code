    Public Class MyDataGridTextColumn
        Inherits DataGridColumn
    
        Private _Binding As Binding
        Public Property Binding As Binding
            Get
                Return Me._Binding
            End Get
            Set(ByVal value As Binding)
                If Me._Binding IsNot value Then
                    Me._Binding = value
                End If
            End Set
        End Property
    
        Protected Overrides Function GenerateElement(cell As System.Windows.Controls.DataGridCell, dataItem As Object) As System.Windows.FrameworkElement
            Dim textBlock As TextBlock = New TextBlock()
            textBlock.Margin = New Thickness(4)
            textBlock.VerticalAlignment = VerticalAlignment.Center
            If Me.Binding IsNot Nothing Then
                textBlock.SetBinding(textBlock.TextProperty, Me.Binding)
            End If
            Return textBlock
        End Function
    
        Protected Overrides Function GenerateEditingElement(cell As System.Windows.Controls.DataGridCell, dataItem As Object) As System.Windows.FrameworkElement
            Dim textBox As TextBox = New TextBox()
            textBox.VerticalAlignment = VerticalAlignment.Stretch
            textBox.Background = New SolidColorBrush(Colors.Transparent)
            If Me.Binding IsNot Nothing Then
                textBox.SetBinding(textBox.TextProperty, Me.Binding)
            End If
            Return textBox
        End Function
    
    End Class
