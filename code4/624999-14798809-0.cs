    public static string TranslateOraceEndianUserID() 
        { 
            MembershipUser myObject = Membership.GetUser(); 
            Guid g = new Guid(myObject.ProviderUserKey.ToString()); 
            byte[] b = g.ToByteArray(); 
            string UserID = BitConverter.ToString(b, 0).Replace("-", string.Empty); 
            return UserID; 
        } 
