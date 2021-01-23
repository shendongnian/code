        [DynamicTestFactory]
        public IEnumerable<Test> LoginAndOut() 
        {
            string method;
            while (Model.graphWalker.HasNextStep())
            {
                method=Model.graphWalker.GetNextStep().ToString();
                if (method == string.Empty)
                    break;
                yield return new TestCase(method, () =>
                    {
                        object obj = this.GetType().InvokeMember(method, BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public, null, this, null);
                    });
            }
         }
