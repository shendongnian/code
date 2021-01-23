	using System.Runtime.InteropServices;
	public static class Program { /*
		[StructLayout(LayoutKind.Sequential)]
		private struct MyData {
			public int Length;
			public byte[] Bytes;
		} */
		[DllImport("MyLib.dll")]
		// __declspec(dllexport) void WINAPI CreateMyDataAlt(BYTE bytes[], int length);
		private static extern void CreateMyDataAlt(byte[] myData, ref int length);
		/* 
		[DllImport("MyLib.dll")]
		private static extern void DestroyMyData(byte[] myData); */
		public static void Main() {
			Console.WriteLine("=== C# test, using IntPtr and Marshal ===");
			int length = 100*1024*1024;
			var myData1 = new byte[length];
			CreateMyDataAlt(myData1, ref length);
			if(0!=length) {
				// MyData myData2 = (MyData)Marshal.PtrToStructure(myData1, typeof(MyData));
				Console.WriteLine("Length: {0}", length);
				/*
				if(myData2.Bytes!=IntPtr.Zero) {
					byte[] bytes = new byte[myData2.Length];
					Marshal.Copy(myData2.Bytes, bytes, 0, myData2.Length); */
				Console.WriteLine("First: {0}, last: {1}", myData1[0], myData1[length-1]); /*
				}
				else {
					Console.WriteLine("myData.Bytes is IntPtr.Zero");
				} */
			}
			else {
				Console.WriteLine("myData is empty");
			}
			// DestroyMyData(myData1);
			Console.ReadKey(true);
		}
	}
