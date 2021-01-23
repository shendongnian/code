    public static bool IsUnicodeSms(this string message)
    {
        var strMap = new Regex(@"^[@£$¥èéùìòÇØøÅå_ÆæßÉ!""#%&'()*+,-./0123456789:;<=>? ¡ABCDEFGHIJKLMNOPQRSTUVWXYZÄÖÑÜ§¿abcdefghijklmnopqrstuvwxyzäöñüà^{}\[~]|€]+$");
        return !strMap.IsMatch(message);
    }
