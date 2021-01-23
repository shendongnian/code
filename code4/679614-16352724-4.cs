    ConsoleApplication1.exe!ConsoleApplication1.Program.AcceptConnection(System.IAsyncResult ar) Line 62	C#
         	System.dll!System.Net.LazyAsyncResult.Complete(System.IntPtr userToken) + 0x69 bytes	
         	System.dll!System.Net.ContextAwareResult.CaptureOrComplete(ref System.Threading.ExecutionContext cachedContext, bool returnContext) + 0xab bytes	
         	System.dll!System.Net.ContextAwareResult.FinishPostingAsyncOp(ref System.Net.CallbackClosure closure) + 0x3c bytes	
         	System.dll!System.Net.Sockets.Socket.BeginAccept(System.AsyncCallback callback, object state) + 0xe3 bytes	
         	ConsoleApplication1.exe!ConsoleApplication1.Program.StartServer(System.Net.IPAddress ipAddr, int port) Line 48 + 0x32 bytes	C#
