       public static class FileServices {
            static FileServices() {
                Reset();
            }
            internal static IFileProxy FileProxy { private get; set; }
            public static void Reset(){
               FileProxy = new FileProxy();
            }
            public static void Delete(string path) {
                FileProxy.Delete(path);
            }
        }
