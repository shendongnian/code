using System.Text;
public static class StringExtensions
{
    /// <summary>
    /// Creates a byte array from the string, using the 
    /// System.Text.Encoding.Default encoding unless another is specified.
    /// </summary>
    public static byte[] ToByteArray(this string str, Encoding encoding = Encoding.Default)
    {
        return encoding.GetBytes(str);
    }
}
And use it like below:
string foo = "bla bla";
// default encoding
byte[] default = foo.ToByteArray();
// custom encoding
byte[] unicode = foo.ToByteArray(Encoding.Unicode);
  [1]: https://stackoverflow.com/a/44703015/1304050
