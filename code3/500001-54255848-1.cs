c#
public static string CreateMD5(ReadOnlySpan<char> input)
{
    var encoding = System.Text.Encoding.UTF8;
    var inputByteCount = encoding.GetByteCount(input);
    using (var md5 = System.Security.Cryptography.MD5.Create())
    {
        Span<byte> bytes = stackalloc byte[inputByteCount];
        Span<byte> destination = stackalloc byte[md5.HashSize / 8];
        encoding.GetBytes(input, bytes);
        // checking the result is not required because this only returns false if "(destination.Length < HashSizeValue/8)", which is never true in this case
        md5.TryComputeHash(bytes, destination, out int _bytesWritten);
        return BitConverter.ToString(destination.ToArray());
    }
}
