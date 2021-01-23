        'Dim store As System.Security.Cryptography.X509Certificates.X509Store = New System.Security.Cryptography.X509Certificates.X509Store
        'store.Open(System.Security.Cryptography.X509Certificates.OpenFlags.ReadOnly)
        'Dim sel As System.Security.Cryptography.X509Certificates.X509Certificate2Collection
        ' If sig <> "" And pass <> "" Then
        Try
            Dim y As Int16 = 200
            ' For i As Integer = 0 To sel.Count - 1
            Dim pdfReader As PdfReader = New PdfReader(src)
            Dim signedPdf = New FileStream(dest, FileMode.Create)
            Try
                Dim cert As X509Certificate2 = New X509Certificate2(sig, pass)
                Dim cp As Org.BouncyCastle.X509.X509CertificateParser = New Org.BouncyCastle.X509.X509CertificateParser()
                Dim chain As Org.BouncyCastle.X509.X509Certificate() = New Org.BouncyCastle.X509.X509Certificate() {cp.ReadCertificate(cert.RawData)}
                Dim stamper As PdfStamper
                stamper = PdfStamper.CreateSignature(pdfReader, signedPdf, "0"c, Nothing, True)
                Dim signatureAppearance As PdfSignatureAppearance = stamper.SignatureAppearance
                'signatureAppearance.SignatureGraphic = Image.GetInstance(pathToSignatureImage)
                signatureAppearance.SetVisibleSignature(name)
                signatureAppearance.CertificationLevel = level
                Dim externalSignature As IExternalSignature = New X509Certificate2Signature(cert, "SHA-1")
                ' Dim digest As IExternalSignature = New BouncyCastleDigest
                ' signatureAppearance.s 
                'signatureAppearance.SetVisibleSignature(New Rectangle(50,50,50,
                signatureAppearance.SignatureRenderingMode = PdfSignatureAppearance.RenderingMode.NAME_AND_DESCRIPTION
                MakeSignature.SignDetached(signatureAppearance, externalSignature, chain, Nothing, Nothing, Nothing, 0, CryptoStandard.CADES)
                ' MakeSignature. 
            Catch ex As Exception
                MsgBox("Signature File Password is not correct for the user Id :" & error_userid)
                'Exit Function
            End Try
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
        ' End If
        Return 0
    End Function
