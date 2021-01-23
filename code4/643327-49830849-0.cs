    public class SavingPlugin
    {
        public static void SaveVariable(string savename, TypeCode tc, object value)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"\" + savename + "." + tc.ToString();
            if (!File.Exists(path))
            {
                var myfile = File.Create(path);
                myfile.Close();
                File.WriteAllText(path, value.ToString());
                File.SetAttributes(path, FileAttributes.Hidden);
            }
            else
            {
                File.SetAttributes(path, FileAttributes.Normal);
                File.WriteAllText(path, value.ToString());
                File.SetAttributes(path, FileAttributes.Hidden);
            }
        }
        public static object GetVariable(string savename, TypeCode tc)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"\" + savename + "." + tc.ToString();
            File.SetAttributes(path, FileAttributes.Normal);
            string txt = File.ReadAllText(path);
            File.SetAttributes(path, FileAttributes.Hidden);
            var value = Convert.ChangeType(txt, tc);
            return value;
        }
        
        public static void DeleteVariable(string savename,TypeCode tc)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"\" + savename + "." + tc.ToString();
            File.SetAttributes(path,FileAttributes.Normal);
            File.Delete(path);
        }
        public static bool Exists(string savename,TypeCode tc)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"\" + savename + "." + tc.ToString();
            bool _true = true;
            try
            {
                File.SetAttributes(path, FileAttributes.Normal);
                File.SetAttributes(path, FileAttributes.Hidden);
            }
            catch
            {
                _true = false;
            }
            return _true;
        }
    }
