    public static void AddImg (string asImgName, string asFilePath, string asUser, string asRemarks)
    {
        var bytes = File.ReadAllBytes(asFilePath);
        ...
        cmd.Parameters.Add("@Image", SqlDbType.VarBinary).Value = bytes;
        ...
        cmd.ExecuteNonQuery();
    }
