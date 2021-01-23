    public static string PrintBytes(this byte[] byteArray)
    {
        var sb = new StringBuilder("new byte[] { ");
        for(var i = 0; i < byteArray.Length;i++)
        {
            var b = byteArray[i];
            sb.Append(b);
            if (i < byteArray.Length -1)
            {
                sb.Append(", ");
            }
        }
        sb.Append(" }");
        return sb.ToString();
    }
