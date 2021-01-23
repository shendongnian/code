    using System;
    using System.Windows;
    using Microsoft.Practices.Prism.Modularity;
    
    namespace MyApp.Module1
    {
        class Module1Module : IModule
        {
            public void Initialize()
            {
                MessageBox.Show("Hello world!");
            }
        }
    }
