    using System;
    using WindowsInstaller;
    
    class MyClass //Notice the class 
    {
     //You can have fields and properties here
        public void MyMethod() // then the code in a method
        {
            string startMenuDir = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
            string shortcutold = Path.Combine(startMenuDir, @"Ohal\TV AMP (Windows XP Mode).lnk");
            if (File.Exists(shortcutold))
                File.Delete(shortcutold);
           // your remaining code .........
    
    
        }
    }
