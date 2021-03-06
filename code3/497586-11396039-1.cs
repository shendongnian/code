    public class CleanString
    {
        public static string UseRegex(string strIn)
        {
            // Replace invalid characters with empty strings.
            return Regex.Replace(strIn, @"[^\w\.@-]", "");
        }
        public static String UseStringBuilder(string strIn)
        {
            const string removeChars = " ?&^$#@!()+-,:;<>’\'-_*";
            // specify capacity of StringBuilder to avoid resizing
            StringBuilder sb = new StringBuilder(strIn.Length);
            foreach (char x in strIn.Where(c => !removeChars.Contains(c)))
            {
                sb.Append(x);
            }
            return sb.ToString();
        }
        public static string UseReplace(string dirtyString)
        {
            string removeChars = " ?&^$#@!()+-,:;<>’\'-_*";
            string result = dirtyString;
            foreach (char c in removeChars)
            {
                result = result.Replace(c.ToString(), string.Empty);
            }
            return result;
        }
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var dirtyString = "sdfdf.dsf8908()=(=(sadfJJLef@ssyd€sdöf////fj()=/§(§&/(\"&sdfdf.dsf8908()=(=(sadfJJLef@ssyd€sdöf////fj()=/§(§&/(\"&sdfdf.dsf8908()=(=(sadfJJLef@ssyd€sdöf";
            var sw = new Stopwatch();
            sw.Start();
            for (var i = 0; i < 1000; i++)
                CleanString.UseReplace(dirtyString);
            sw.Stop();
            Debug.WriteLine("CleanString.UseReplace: " + sw.ElapsedMilliseconds.ToString());
            sw.Reset();
            sw.Start();
            for (var i = 0; i < 1000; i++)
                CleanString.UseStringBuilder(dirtyString);
            sw.Stop();
            Debug.WriteLine("CleanString.UseStringBuilder: " + sw.ElapsedMilliseconds.ToString());
            sw.Reset();
            sw.Start();
            for (var i = 0; i < 1000; i++)
                CleanString.UseRegex(dirtyString);
            sw.Stop();
            Debug.WriteLine("CleanString.UseRegex: " + sw.ElapsedMilliseconds.ToString());
        }
    }
