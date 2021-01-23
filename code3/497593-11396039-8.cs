    public class CleanString
    {
        //by MSDN http://msdn.microsoft.com/en-us/library/844skk0h(v=vs.71).aspx
        public static string UseRegex(string strIn)
        {
            // Replace invalid characters with empty strings.
            return Regex.Replace(strIn, @"[^\w\.@-]", "");
        }
        // by Paolo Tedesco
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
        // by Paolo Tedesco, but using a HashSet
        public static String UseStringBuilderWithHashSet(string strIn)
        {
            var hashSet = new HashSet<char>(" ?&^$#@!()+-,:;<>’\'-_*");
            // specify capacity of StringBuilder to avoid resizing
            StringBuilder sb = new StringBuilder(strIn.Length);
            foreach (char x in strIn.Where(c => !hashSet.Contains(c)))
            {
                sb.Append(x);
            }
            return sb.ToString();
        }
        // by SteveDog
        public static string UseStringBuilderWithHashSet2(string strIn)
        {
            var hashSet = new HashSet<char>(" ?&^$#@!()+-,:;<>’\'-_*");
            StringBuilder result = new StringBuilder(strIn.Length);
            foreach (char c in strIn)
                if (hashSet.Contains(c))
                    result.Append(c);
            return result.ToString();
        }
        // original by patel.milanb
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
        // by L.B
        public static string UseWhere(string dirtyString)
        {
            return new String(dirtyString.Where(Char.IsLetterOrDigit).ToArray());
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
            var iterations = 50000;
            
            sw.Start();
            for (var i = 0; i < iterations; i++)
                CleanString.<SomeMethod>(dirtyString);
            sw.Stop();
            Debug.WriteLine("CleanString.<SomeMethod>: " + sw.ElapsedMilliseconds.ToString());
            sw.Reset();
  
            ....
            <repeat>
            ....       
        }
    }
