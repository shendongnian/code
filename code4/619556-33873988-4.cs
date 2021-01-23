    public TokenValidation ValidateToken(string reason, MyUser user, string token)
    {
        var result = new TokenValidation();
        byte[] data     = Convert.FromBase64String(token);
        byte[] _time     = data.Take(8).ToArray();
        byte[] _key      = data.Skip(8).Take(16).ToArray();
        byte[] _reason   = data.Skip(24).Take(4).ToArray();
        byte[] _Id       = data.Skip(28).ToArray();
    
        DateTime when = DateTime.FromBinary(BitConverter.ToInt64(_time, 0));
        if (when < DateTime.UtcNow.AddHours(-24))
        {
            result.Errors.Add( TokenValidationStatus.Expired);
        }
        
        Guid gKey = new Guid(_key);
        if (gKey.ToString() != user.SecurityStamp)
        {
            result.Errors.Add(TokenValidationStatus.WrongGuid);
        }
    
        if (reason != GetString(_reason))
        {
            result.Errors.Add(TokenValidationStatus.WrongPurpose);
        }
    
        if (user.Id.ToString() != GetString(_Id))
        {
            result.Errors.Add(TokenValidationStatus.WrongUser);
        }
        
        return result;
    }
