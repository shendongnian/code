    public class SMSHelper
    {
    private string msg;     // <-- #1
    private string convertToISOfromUtf8(String msg /* <-- #2 */, String to, String from)
    {
    
        String iso_msg = null;
        if (from.Equals("UTF-8"))
        {
            System.Text.Encoding iso = Encoding.GetEncoding("ISO-8859-1");
            System.Text.Encoding utf8 = Encoding.UTF8;
    
            byte[] utfBytes = utf8.GetBytes(msg);
            byte[] isoBytes = Encoding.Convert(utf8, iso, utfBytes);
            String msg = iso.GetString(isoBytes);    // <-- #3
        }
