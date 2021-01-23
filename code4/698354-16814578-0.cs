        protected override void InitializeCulture()
        {
            try
            {
                string langID = "en-us";
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(langID);
                base.InitializeCulture();
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
        }
