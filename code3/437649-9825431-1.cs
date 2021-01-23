    StringBuilder sb = new StringBuilder();
    PdfReader reader = new PdfReader(pdf);
    AcroFields af = reader.AcroFields;
    ArrayList  names = af.GetSignatureNames();
    for (int i = 0; i < names.Count; ++i) {
      String name = (string)names[i];
      PdfPKCS7 pk = af.VerifySignature(name);
      sb.AppendFormat("Signature field name: {0}\n", name);
      sb.AppendFormat("Signature signer name: {0}\n", pk.SignName);
      sb.AppendFormat("Signature date: {0}\n", pk.SignDate);
      sb.AppendFormat("Signature country: {0}\n",  
        PdfPKCS7.GetSubjectFields(pk.SigningCertificate).GetField("C")
      );
      sb.AppendFormat("Signature organization: {0}\n",  
        PdfPKCS7.GetSubjectFields(pk.SigningCertificate).GetField("O")
      );
      sb.AppendFormat("Signature unit: {0}\n",  
        PdfPKCS7.GetSubjectFields(pk.SigningCertificate).GetField("OU")
      );
    }
