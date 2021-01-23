    using System;
    using System.Collections.Generic;
    class Base36
    {
    #region public methods
    public static string ByteArrayToBase36String(byte[] bytes)
    {
        string result = string.Empty;
        result = Encode36((ulong)bytes.Length).PadLeft(BASE36_LENGTH_BLOC_SIZE_36, '0');
        if (bytes.Length > 0)
        {
            List<byte[]> byteslist = SplitBytes(bytes, 8);
            if (byteslist[byteslist.Count - 1].Length < 8)
            {
                byte[] newLastArray = new byte[8];
                byteslist[byteslist.Count - 1].CopyTo(newLastArray, 0);
                byteslist[byteslist.Count - 1] = newLastArray;
            }
            foreach (byte[] byteArray in byteslist)
            {
                ulong value = 0;
                //for (int i = 0; i < byteArray.Length; i++) value = value * 256 + byteArray[i];
                value = BitConverter.ToUInt64(byteArray, 0);
                result = result + Encode36(value).PadLeft(BASE36_BLOC_SIZE_36, '0');
            }
        }
        return result;
    }
    public static byte[] Base36StringToByteArray(string input)
    {
        byte[] result = new byte[0];
        if (input.Length >= BASE36_LENGTH_BLOC_SIZE_36)
        {
            int arrayLength = (int)Decode36(input.Substring(0, BASE36_LENGTH_BLOC_SIZE_36));
            string data = input.Remove(0, BASE36_LENGTH_BLOC_SIZE_36);
            List<byte[]> bytesList = new List<byte[]>();
            foreach (string value36 in new List<string>(SplitStringByLength(data, BASE36_BLOC_SIZE_36)))
            {
                byte[] byteArray = BitConverter.GetBytes(Decode36(value36));
                bytesList.Add(byteArray);
            }
            result = JoinBytes(bytesList);
            Array.Resize(ref result, arrayLength);
        }
        return result;
    }
    #endregion
    #region Const
    private const int BASE36_LENGTH_BLOC_SIZE_36 = 6;
    private const int BASE36_BLOC_SIZE_36 = 13; //Encode36(ulong.MaxValue).Length;
    #endregion
    #region private methods
    static string _CharList36 = string.Empty;
    static private string CharList36
    {
        get
        {
            if (_CharList36.Length < 36)
            {
                char[] array = new char[36];
                for (int i = 0; i < 10; i++) array[i] = (char)(i + 48);
                for (int i = 0; i < 26; i++) array[i + 10] = (char)(i + 97);
                _CharList36 = new string(array);
            }
            return _CharList36;
        }
    }
    private static List<string> SplitStringByLength(string str, int chunkSize)
    {
        List<string> list = new List<string>();
        int i;
        for (i = 0; i < str.Length / chunkSize; i++)
        {
            list.Add(str.Substring(i * chunkSize, chunkSize));
        }
        i = i * chunkSize;
        if (i < str.Length - 1)
            list.Add(str.Substring(i, str.Length - i));
        return list;
    }
    private static String Encode36(ulong input)
    {
        if (input < 0) throw new ArgumentOutOfRangeException("input", input, "input cannot be negative");
        char[] clistarr = CharList36.ToCharArray();
        var result = new Stack<char>();
        while (input != 0)
        {
            result.Push(clistarr[input % 36]);
            input /= 36;
        }
        return new string(result.ToArray()).ToUpper();
    }
    private static ulong Decode36(string input)
    {
        var reversed = ReverseString(input.ToLower());
        ulong result = 0;
        int pos = 0;
        foreach (char c in reversed)
        {
            result += (ulong)CharList36.IndexOf(c) * (ulong)Math.Pow(36, pos);
            pos++;
        }
        return result;
    }
    private static string ReverseString(string text)
    {
        char[] cArray = text.ToCharArray();
        string reverse = String.Empty;
        for (int i = 0; i < cArray.Length / 2; i++)
        {
            char c = cArray[i];
            cArray[i] = cArray[cArray.Length - 1 - i];
            cArray[cArray.Length - 1 - i] = c;
        }
        return new string(cArray);
    }
    private static byte[] StringToBytes(string str)
    {
        byte[] bytes = new byte[str.Length * sizeof(char)];
        System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
        return bytes;
    }
    private static List<byte[]> SplitBytes(byte[] bytes, int length)
    {
        List<byte[]> result = new List<byte[]>();
        int position = 0;
        while (bytes.Length - position > length)
        {
            byte[] temp = new byte[length];
            for (int i = 0; i < temp.Length; i++) temp[i] = bytes[i + position];
            position += length;
            result.Add(temp);
        }
        if (position < bytes.Length)
        {
            byte[] temp = new byte[bytes.Length - position];
            for (int i = 0; i + position < bytes.Length; i++) temp[i] = bytes[i + position];
            result.Add(temp);
        }
        return result;
    }
    private static string BytesToString(byte[] bytes)
    {
        char[] chars = new char[bytes.Length / sizeof(char)];
        System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
        return new string(chars);
    }
    private static byte[] JoinBytes(List<byte[]> listBytes)
    {
        int totalLength = 0;
        foreach (byte[] bytes in listBytes) totalLength += bytes.Length;
        byte[] result = new byte[totalLength];
        int position = 0;
        foreach (byte[] bytes in listBytes)
            for (int i = 0; i < bytes.Length; i++)
            {
                result[position] = bytes[i];
                position++;
            }
        return result;
    }
    #endregion
    } 
