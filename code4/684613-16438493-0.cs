    public delegate void MyCallback();
    [DllImport("data_acquisition_sys.dll")]
    public static extern int MyUnmanagedApi(MyCallback callback);
    
    static void Main(string[] args) {
    
        MyUnmanagedApi(
        delegate()
        {
            Console.WriteLine("Called back by unmanaged side");
        }
        );
        }
    }
