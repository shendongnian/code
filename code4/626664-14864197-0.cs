    using System.ComponentModel.Composition;
    using Microsoft.Expression.Extensibility;
    namespace Demo.Extension
    {
        [Export(typeof (IPackage))]
        public class Demo : IPackage
        {
            public void Load(IServices services)
            {
            }
    
            public void Unload()
            {
            }
        }
    }
