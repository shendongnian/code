        [TestMethod]
        public void TestBindings
        {
            var dependencies = new MyDependencies();
            var kernel = new StandardKernel(dependencies);
            
            foreach (var binding in dependencies.Bindings)
            {
                kernel.Get(binding.Service);
            }
        }
