    For example [VB.NET]: 
    
    Dim cspParam as CspParameters = new CspParameters()
    cspParam.Flags = CspProviderFlags.UseMachineKeyStore
    Dim RSA As System.Security.Cryptography.RSACryptoServiceProvider
               = New System.Security.Cryptography.RSACryptoServiceProvider(cspParam)
    
    The key information from the cspParam object above can be saved via:
    
    Dim publicKey as String = RSA.ToXmlString(False) ' gets the public key
    Dim privateKey as String = RSA.ToXmlString(True) ' gets the private key
    
    The above methods enable you to convert the public and / or private keys to Xml Strings.
     And of course, as you would guess, there is a corresponding FromXmlString method to get them back. 
     So to encrypt some data with the Public key. The no-parameter constructor is used as we are loading our keys from XML and 
     do not need to create a new cspParams object:
    
    Dim str as String = "HelloThere"
    Dim RSA2 As RSACryptoServiceProvider = New RSACryptoServiceProvider()
    ' ---Load the private key---
    RSA2.FromXmlString(privateKey)
    Dim EncryptedStrAsByt() As Byte =RSA2.Encrypt(System.Text.Encoding.Unicode.GetBytes(str),False)
    Dim EncryptedStrAsString = System.Text.Encoding.Unicode.GetString(EncryptedStrAsByt)
    
    and as a "proof of concept", to DECRYPT the same data, but now using the Public key:
    
    Dim RSA3 As RSACryptoServiceProvider = New RSACryptoServiceProvider(cspParam)
    '---Load the Public key---
    RSA3.FromXmlString(publicKey)
    Dim DecryptedStrAsByt() As Byte =RSA3.Decrypt(System.Text.Encoding.Unicode.GetBytes(EncryptedStrAsString), False)
    Dim DecryptedStrAsString = System.Text.Encoding.Unicode.GetString(DecryptedStrAsByt)
