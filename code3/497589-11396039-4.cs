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
        public static string UseStringBuilderWithHashSet2(string dirtyString)
        {
            HashSet<char> removeChars = new HashSet<char>(" ?&^$#@!()+-,:;<>’\'-_*");
            StringBuilder result = new StringBuilder(dirtyString.Length);
            foreach (char c in dirtyString)
                if (removeChars.Contains(c))
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
            var iterations = 5000;
            
            sw.Start();
            for (var i = 0; i < iterations; i++)
                CleanString.UseReplace(dirtyString);
            sw.Stop();
            Debug.WriteLine("CleanString.UseReplace: " + sw.ElapsedMilliseconds.ToString());
            sw.Reset();
            sw.Start();
            for (var i = 0; i < iterations; i++)
                CleanString.UseStringBuilder(dirtyString);
            sw.Stop();
            Debug.WriteLine("CleanString.UseStringBuilder: " + sw.ElapsedMilliseconds.ToString());
            sw.Reset();
            sw.Start();
            for (var i = 0; i < iterations; i++)
                CleanString.UseStringBuilderWithHashSet(dirtyString);
            sw.Stop();
            Debug.WriteLine("CleanString.UseStringBuilderWithHashSet: " + sw.ElapsedMilliseconds.ToString());
            sw.Reset();
            sw.Start();
            for (var i = 0; i < iterations; i++)
                CleanString.UseStringBuilderWithHashSet2(dirtyString);
            sw.Stop();
            Debug.WriteLine("CleanString.UseStringBuilderWithHashSet2: " + sw.ElapsedMilliseconds.ToString());
            sw.Reset();
            sw.Start();
            for (var i = 0; i < iterations; i++)
                CleanString.UseRegex(dirtyString);
            sw.Stop();
            Debug.WriteLine("CleanString.UseRegex: " + sw.ElapsedMilliseconds.ToString());
        }
    }
