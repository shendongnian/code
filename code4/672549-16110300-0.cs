    class EncryptedRequest 
    { 
        //Name of the request type 
        public string Type { get; set; }
        //Serialized Request DTO using something like JSON 
        public string EncryptedBody { get; set; }
        //optional: let server the private key that was used (if multiple) 
        public string PrivateKeyMd5Hash; 
    } 
    class EncryptedResponse 
    { 
        //Name of the response type 
        public string Type { get; set; } 
        //Serialized Response DTO 
        public string EncryptedBody { get; set; } 
        //optional 
        public string PublicKeyMd5Hash { get; set; } 
    } 
