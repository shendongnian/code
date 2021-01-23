            Encoding latinEncoding = Encoding.GetEncoding("Windows-1252");
            Encoding hebrewEncoding = Encoding.GetEncoding("Windows-1255");
            string msys = "=F0=E0 =F6=F8=E5 =E0=E9=FA=E9 =F7=F9=F8 =E1=E1=F7=F9=E4 =E1=E8=EC=F4=E5=EF";
            msys = System.Web.HttpUtility.UrlDecode(msys.Replace('=', '%').Replace(" ", "%20"), latinEncoding);
            byte[] latinBytes = latinEncoding.GetBytes(msys);
            string hebrewString = hebrewEncoding.GetString(latinBytes);
