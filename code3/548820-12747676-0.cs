	e.ServiceConfiguration.SecurityTokenHandlers.AddOrReplace(New SessionSecurityTokenHandler(New System.Collections.ObjectModel.ReadOnlyCollection(Of CookieTransform)(New List(Of CookieTransform)() From { _
		New DeflateCookieTransform(), _
		New RsaEncryptionCookieTransform(cookieProtectionCertificate), _
		New RsaSignatureCookieTransform(cookieProtectionCertificate) _
	})))
End Sub
