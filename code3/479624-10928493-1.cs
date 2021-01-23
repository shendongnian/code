        private void WebMethodAction()
        {
            Execute(() =>
            {
                Console.WriteLine("Hello World");
            });
        }
        private int WebMethodFunc(int a, int b)
        {
            return Execute(() =>
            {
                return (double)a / (double)b;
            });
        }        
        public void Execute(Action action)
        {
            // call Execute<T> and discard result
            Execute(() => { action.Invoke(); return true; });
        }
        public T Execute<T>(Func<T> func)
        {
            T result = func.Invoke();
            // cleanup
            Console.WriteLine("Cleanup");
            return result;
        }
