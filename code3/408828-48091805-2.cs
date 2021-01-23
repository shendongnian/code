		using System.Diagnostics;
		using System.Runtime.Serialization.Formatters.Binary;
		using System.Runtime.InteropServices;
		using System.IO;
		using System;
		namespace ConsoleApp1 {
			class Program {
				[DllImport(@"C:\Projects\ConsoleApp1\Debug\MyDll.dll", EntryPoint = "?return_callback_val@@YGHP6AHXZ@Z")]
				static extern int return_callback_val(IntPtr callback);
				[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
				delegate int CallbackDelegate();
				static int Callback() {
					throw new Exception("something went wrong");
				}
				static void Main() {
					CallbackDelegate @delegate = new CallbackDelegate(Callback);
					IntPtr callback = Marshal.GetFunctionPointerForDelegate(@delegate);
					try {
						int returnedVal = return_callback_val(callback);
					}
					catch(Exception e) {
						UnmanagedHelper.SetLastException(e);
					}
					var x = UnmanagedHelper.GetLastException();
					Console.WriteLine("exception: {0}", x);
				}
			}
		}
	---
		namespace ConsoleApp1 {
			public static class ExceptionSerializer {
				public static byte[] Serialize(Exception x) {
					using(var ms = new MemoryStream { }) {
						m_formatter.Serialize(ms, x);
						return ms.ToArray();
					}
				}
				public static Exception Deserialize(byte[] bytes) {
					using(var ms = new MemoryStream(bytes)) {
						return (Exception)m_formatter.Deserialize(ms);
					}
				}
				static readonly BinaryFormatter m_formatter = new BinaryFormatter { };
			}
		}
	---
		namespace ConsoleApp1 {
			public static class UnmanagedHelper {
				[DllImport(@"C:\Projects\ConsoleApp1\Debug\MyDll.dll", EntryPoint = "?StoreException@@YGHHQAE@Z")]
				static extern int StoreException(int length, byte[] bytes);
				[DllImport(@"C:\Projects\ConsoleApp1\Debug\MyDll.dll", EntryPoint = "?RetrieveException@@YGHHQAE@Z")]
				static extern int RetrieveException(int length, byte[] bytes);
				public static void SetLastException(Exception x) {
					var bytes = ExceptionSerializer.Serialize(x);
					var ret = StoreException(bytes.Length, bytes);
					if(0!=ret) {
						Console.WriteLine("bytes too long; max available size is {0}", ret);
					}
				}
				public static Exception GetLastException() {
					var bytes = new byte[1024];
					var ret = RetrieveException(bytes.Length, bytes);
					if(0==ret) {
						return ExceptionSerializer.Deserialize(bytes);
					}
					else if(~0!=ret) {
						Console.WriteLine("buffer too small; total {0} bytes are needed", ret);
					}
					return null;
				}
			}
		}
