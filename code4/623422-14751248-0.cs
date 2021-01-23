    public List<string> GetRaumImageName()
    {
        var md5 = System.Security.Cryptography.MD5.Create();
        List<string> hashes = new List<string>();
        StringBuilder sb = new StringBuilder();
        byte[] hash = new byte[0];
        foreach (PanelView panelView in pv)
        {
            hash = md5.ComputeHash(Encoding.ASCII.GetBytes(panelView.Title));
            //clear sb
            sb.Remove(0, sb.Length);
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            hashes.Add(sb.ToString());
        }
        return hashes;
    }
