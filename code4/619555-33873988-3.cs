    public string GenerateToken(string reason, MyUser user)
    {
        byte[] _time     = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
        byte[] _key      = Guid.Parse(user.SecurityStamp).ToByteArray();
        byte[] _Id       = GetBytes(user.Id.ToString());
        byte[] _reason   = GetBytes(reason);
        byte[] data       = new byte[_time.Length + _key.Length + _reason.Length+_Id.Length];
    
        System.Buffer.BlockCopy(_time, 0, data, 0, _time.Length);
        System.Buffer.BlockCopy(_key , 0, data, _time.Length, _key.Length);
        System.Buffer.BlockCopy(_reason, 0, data, _time.Length + _key.Length, _reason.Length);
        System.Buffer.BlockCopy(_Id, 0, data, _time.Length + _key.Length+ _reason.Length, _Id.Length);
    
        return Convert.ToBase64String(data.ToArray());
    }
