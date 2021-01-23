        public interface IFileProxy {
            void Delete(string path);
        }
        public class FileProxy : IFileProxy {
            public void Delete(string path) {
                System.IO.File.Delete(path);
            }
        }
        public class MyClass {
            private IFileProxy _fileProxy;
            public MyClass(IFileProxy fileProxy) {
                _fileProxy = fileProxy;
            }
            public void DoSomethingAndDeleteFile(string path) {
                // Do Something with file
                // ...
                // Delete
                System.IO.File.Delete(path);
            }
            public void DoSomethingAndDeleteFileUsingProxy(string path) {
                // Do Something with file
                // ...
                // Delete
                _fileProxy.Delete(path);
            }
        }
