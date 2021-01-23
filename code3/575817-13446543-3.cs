    public class Person
    {
     public string firstName { get; set; }
     public SocialSecurityNumber SSN { get; set; }
    }
    public class SocialSecurityNumber
    {
     public string SSN { get; set; }
     public string Encrypted { get; set; }//set this to "EncryptedTrue" or something
                                          //similar in order to handle it in the post
    }
