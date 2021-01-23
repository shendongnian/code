        public class MyClass
        {
	        private DependencyOne dep1;
	        public MyClass(WhatEverContainer container)
	        {
		        dep1 = container.Resolve<DependencyOne>();
	        }
        }
