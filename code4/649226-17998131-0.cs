	' The controldesigner don't always save properties which are changed directly :/
	Private Sub SetValue(itm As Item, pName$, val As Object)
		Dim Prop As PropertyDescriptor = TypeDescriptor.GetProperties(itm.Page)(pName)
		If Prop IsNot Nothing AndAlso Prop.PropertyType Is val.GetType Then Prop.SetValue(itm.Page, val)
	End Sub
