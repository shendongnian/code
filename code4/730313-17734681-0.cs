     private void CheckCert(object sender, ValidateServerCertificateEventArgs e)
     {
      if (SslPolicyErrors.None == e.CertificatePolicyErrors)
      {
         return;
      }
    
      DialogResult oResult = MessageBox.Show("Accept invalid certificate\nYOUR DETAILS HERE", "Certificate Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2));
    
     if (DialogResult.Yes == oResult) {
       e.ValidityState = CertificateValidity.ForceValid;
     }
     else
     {  
       e.ValidityState = CertificateValidity.ForceInvalid;
     }
