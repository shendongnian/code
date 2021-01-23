    public class LabViewWrapper : IYourCustomClass
    {
        private IYourCustomClass _labViewClass;
        private string labviewPath = "Full Path to labview dll";
        public LabViewWrapper()
        {
            Assembly assembly;
            try
            {
                using (FileStream fs = File.OpenRead(labviewPath))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        byte[] buffer = new byte[1024];
                        int read = 0;
                        while ((read = fs.Read(buffer, 0, 1024)) > 0)
                            ms.Write(buffer, 0, read);
                        assembly = Assembly.Load(ms.ToArray());
                        ms.Close();
                    }
                    fs.Close();
                }
                Type t = assembly.GetType(IYourCustomClass);
                _labViewClass= (IYourCustomClass)Activator.CreateInstance(t);
            }
            catch
            {
                // Unable to load dll dynamically
            }
        }
        // Implement all the methods in your interface with something like the following:
        /// <summary>
        /// Your Custom Method
        /// </summary>
        public void CustomLabViewMethod()
        {
            _labViewClass.CustomLabViewMethod();
        }
    }
