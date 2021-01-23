    Dim myForm As Form = btnAuthorise.FindForm()
    For Each c As Control In myForm.Controls
                    If c.Name = "tabControlName" Then
                        DirectCast(c, System.Windows.Forms.TabControl).Invalidate()
                        DirectCast(c, System.Windows.Forms.TabControl).Refresh() 'force the call to the drawitem event
                    End If
     Next
