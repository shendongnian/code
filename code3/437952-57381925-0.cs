    AddDateBinding(Me.txtPhantomBlockIrrDate, Me.bsPhantomBlock, "IRRADIATE_DATE")
      Public Sub AddDateBinding(control As Control, bs As BindingSource, field As String)
            Dim controlProperty As String = ""
    
            If TypeOf (control) Is TextBox Then
                controlProperty = "Text"
            End If
            If TypeOf (control) Is ComboBox Then
                controlProperty = "SelectedValue"
            End If
    
            control.DataBindings.Add(New System.Windows.Forms.Binding(controlProperty, bs, field, True, DataSourceUpdateMode.OnValidation, Nothing, "MM/dd/yyyy"))
            AddHandler control.Validating, AddressOf DateValidating
    
        End Sub
    
        Public Sub DateValidating(sender As Object, e As System.ComponentModel.CancelEventArgs)
            e.Cancel = False
            Try
                If CType(sender, Control).Text = "" Then
                    e.Cancel = False
                    Dim fieldName As String = CType(sender, Control).DataBindings(0).BindingMemberInfo.BindingField
                    Dim bs As BindingSource = CType(CType(sender, Control).DataBindings(0).DataSource, BindingSource)
                    Dim propInfo As Reflection.PropertyInfo = bs.Current.GetType().GetProperty(fieldName)
                    propInfo.SetValue(bs.Current, Nothing, Nothing)
                Else
                    e.Cancel = False
                    Dim fieldName As String = CType(sender, Control).DataBindings(0).BindingMemberInfo.BindingField
                    Dim bs As BindingSource = CType(CType(sender, Control).DataBindings(0).DataSource, BindingSource)
                    Dim propInfo As Reflection.PropertyInfo = bs.Current.GetType().GetProperty(fieldName)
                    propInfo.SetValue(bs.Current, CType(sender, Control).Text, Nothing)
                End If
    
            Catch ex As Exception
    
            End Try
        End Sub
