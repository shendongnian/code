    public class LabView
    {
        private LabViewClass _labView;
        private string labviewPath = "Full Path to labview dll";
        public LabView()
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
                Type t = assembly.GetType(LabViewClass);
                _labView = (LabViewClass)Activator.CreateInstance(t);
            }
            catch
            {
                // Unable to load dll dynamically
            }
        }
        /// <summary>
        /// Wrap every labview method you are using
        /// </summary>
        public void LabviewMethod()
        {
            _labView.LabViewMethod();
        }
    }
