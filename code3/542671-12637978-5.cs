        public void DoSomethingAndDeleteFileUsingStaticProxy(string path) {
                // Do Something with file
                // ...
                // Delete
                FileServices.Delete(path);
        }
