        public static void Main()
        {
            var sth = new SomethingVeryLongLived(…);
            try
            {
                Application.Run(new SomeForm(…));
            }
            finally
            {
                SomethingVeryLongLived.Terminate();
            }
        }
