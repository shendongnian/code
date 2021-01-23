        public void processAction<T>(Action<T> action, T item) {
            action(item);            
        }
            Action<int> customAction = (i) => Console.WriteLine(i);
            processAction(customAction, 123);
            Action<string> customAction2 = (s) => Console.WriteLine(s);
            processAction(customAction2, "Frank Borland");
