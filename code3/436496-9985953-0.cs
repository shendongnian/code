    namespace HelloWorld
    {
        #region NameSpaces
    
        using System;
        using Cinchoo.Core.Configuration;
    
        #endregion NameSpaces
    
        [ChoConfigurationSection("sample")]
        public class SampleConfigSection : ChoConfigurableObject
        {
            [ChoPropertyInfo("name", DefaultValue="Mark")]
            public string Name;
    
            [ChoPropertyInfo("message", DefaultValue="Hello World!")]
            public string Message;
        }
    
        static void Main(string[] args)
        {
            SampleConfigSection sampleConfigSection = new SampleConfigSection();
            Console.WriteLine(sampleConfigSection.ToString());
        }
    
    }
