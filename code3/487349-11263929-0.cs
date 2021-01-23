    using System;
    using Microsoft.Build.Framework;
    using System.IO;
    
    namespace MyBuildProcess
    {
        public class CopyGeneratedEntities : ITask
        {
            private IBuildEngine _buildEngine;
            public IBuildEngine BuildEngine
            {
                get { return _buildEngine; }
                set { _buildEngine = value; }
            }
    
            private ITaskHost _hostObject;
            public ITaskHost HostObject
            {
                get { return _hostObject; }
                set { _hostObject = value; }
            }
    
            public bool Execute()
            {
    			// Copy generated Product entity to EF project
                if (File.Exists(@"C:\MySolution\EntitiesGenerator\ProductEntity.cs"))
                {
                    File.Copy(@"C:\MySolution\EntitiesGenerator\ProductEntity.cs",
                        @"C:\MySolution\Entities\ProductEntity.cs", true);
                }
    
                return true;
            }
    
            
        }
    }
