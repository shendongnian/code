	Private Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
		Dim defaultTableData = New DefaultTableData()
		defaultTableData.CheckAndUpdate()
		If ConfigurationManager.AppSettings("RSAConfigSwitch").ToString().ToUpper() = "ON" Then
			AddHandler FederatedAuthentication.ServiceConfigurationCreated, AddressOf FederatedAuthentication_ServiceConfigurationCreated
		End If
	End Sub
	Private Sub FederatedAuthentication_ServiceConfigurationCreated(ByVal sender As Object, ByVal e As Microsoft.IdentityModel.Web.Configuration.ServiceConfigurationCreatedEventArgs)
		Dim certName As String = ConfigurationManager.AppSettings("CertificateName").ToString() ' read from web.config
		Dim store As New System.Security.Cryptography.X509Certificates.X509Store(System.Security.Cryptography.X509Certificates.StoreName.My, System.Security.Cryptography.X509Certificates.StoreLocation.LocalMachine)
		store.Open(OpenFlags.ReadOnly)
		Dim col As System.Security.Cryptography.X509Certificates.X509Certificate2Collection = store.Certificates.Find(System.Security.Cryptography.X509Certificates.X509FindType.FindBySubjectName, certName, True)
		Dim cookieProtectionCertificate = col(0)
		e.ServiceConfiguration.SecurityTokenHandlers.AddOrReplace(New SessionSecurityTokenHandler(New System.Collections.ObjectModel.ReadOnlyCollection(Of CookieTransform)(New List(Of CookieTransform) From {
			New DeflateCookieTransform(),
			New RsaEncryptionCookieTransform(cookieProtectionCertificate),
			New RsaSignatureCookieTransform(cookieProtectionCertificate)
		})))
	End Sub
