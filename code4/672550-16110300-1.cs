    class EncryptedService : Service 
    { 
        const string PublicKey = ...; 
        const string PrivateKey = ...; 
    
        EncryptedResponse Any(EncryptedRequest request) 
        { 
            var requestType = Type.GetType("{0}.{1}" 
                .Fmt(typeof(EncryptedRequest).Namespace, request.Type)); 
    
            var json = CryptUtils.Decrypt(PrivateKey, request.EncryptedBody); 
            var requestDto = JsonSerializer.DeserializeFromString(json,requestType); 
            var responseDto = GetAppHost().Config.ServiceController
                .Execute(requestDto, base.RequestContext); 
    
            return new EncryptedResponse { 
               Type = responseDto.GetType().Name, 
               EncryptedBody = CryptUtils.Encrypt(PublicKey, responseDto.ToJson()), 
            }; 
        } 
    } 
