	Public Enum StoredPropertyScope As SByte
		SessionAndCookies = 0
		SessionOnly = 1
		CookiesOnly = 2
	End Enum
	Public Shared Function GetStoredProperty(ByVal group As String, ByVal Key As String, Optional scope As StoredPropertyScope = StoredPropertyScope.SessionAndCookies) As Object
		If (scope = StoredPropertyScope.SessionAndCookies Or scope = StoredPropertyScope.SessionOnly) And Not (HttpContext.Current.Session(group & "-" & Key) Is Nothing) Then
			Return HttpContext.Current.Session(group & "-" & Key)
		Else
			If (scope = StoredPropertyScope.SessionAndCookies Or scope = StoredPropertyScope.CookiesOnly) And Not (Request.Cookies(group) Is Nothing) Then
				Return Request.Cookies(group)(Key)
			Else
				Return Nothing
			End If
		End If
	End Function
	Public Shared Sub SetStoredProperty(ByVal group As String, ByVal key As String, value As String, Optional scope As StoredPropertyScope = StoredPropertyScope.SessionAndCookies)
		If scope = StoredPropertyScope.SessionAndCookies Or scope = StoredPropertyScope.CookiesOnly Then
			If Request.Cookies(group) Is Nothing Then
				Response.Cookies(group)(key) = value
				Response.Cookies(group).Expires = Now.AddYears(1)
			Else
				Dim OldValues As NameValueCollection = Request.Cookies.Get(group).Values
				OldValues.Item(key) = value
				Response.Cookies.Get(group).Values.Clear()
				Response.Cookies.Get(group).Values.Add(OldValues)
				Response.Cookies(group).Expires = Now.AddYears(1)
			End If
		End If
		If scope = StoredPropertyScope.SessionAndCookies Or scope = StoredPropertyScope.SessionOnly Then
			HttpContext.Current.Session(group & "-" & key) = value
		End If
	End Sub
	Public Overloads Shared Sub RemoveStoredProperty(ByVal group As String, ByVal key As String, Optional scope As StoredPropertyScope = StoredPropertyScope.SessionAndCookies)
		If scope = StoredPropertyScope.SessionAndCookies Or scope = StoredPropertyScope.CookiesOnly Then
			If Not (Request.Cookies(group) Is Nothing) AndAlso Request.Cookies(group).HasKeys Then
				Dim OldValues As NameValueCollection = Request.Cookies.Get(group).Values
				OldValues.Remove(key)
				Response.Cookies.Get(group).Values.Clear()
				Response.Cookies.Get(group).Values.Add(OldValues)
				Response.Cookies(group).Expires = Now.AddYears(1)
			End If
		End If
		If scope = StoredPropertyScope.SessionAndCookies Or scope = StoredPropertyScope.SessionOnly Then
			HttpContext.Current.Session.Remove(group & "-" & key)
		End If
	End Sub
	Public Overloads Shared Sub RemoveStoredProperty(ByVal group As String)
		'remove all from cookies only
		Response.Cookies(group).Expires = DateTime.Now.AddDays(-1)
	End Sub
	Public Shared Function CheckStoredProperty(ByVal group As String, ByVal key As String) As StoredPropertyScope
		'return where is property stored or -1 if not exists
		Dim result As StoredPropertyScope = -1
		If (Not Request.Cookies(group) Is Nothing) AndAlso (Not Request.Cookies(group)(key) Is Nothing) Then
			result = StoredPropertyScope.CookiesOnly
		End If
		If Not HttpContext.Current.Session(group & "-" & key) Is Nothing Then
			If result = -1 Then result = StoredPropertyScope.SessionOnly Else result = StoredPropertyScope.SessionAndCookies
		End If
		Return result
	End Function
