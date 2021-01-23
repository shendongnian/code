	public partial class TestClass {
		public static void TestMethod() {
			var diskGeometry=DiskGeometry.FromDevice(@"\\.\PhysicalDrive3");
			var cubicAddress=diskGeometry.MaximumCubicAddress;
			Console.WriteLine("            media type: {0}", diskGeometry.MediaTypeName);
			Console.WriteLine();
			Console.WriteLine("maximum linear address: {0}", diskGeometry.MaximumLinearAddress);
			Console.WriteLine("  last cylinder number: {0}", cubicAddress.Cylinder);
			Console.WriteLine("      last head number: {0}", cubicAddress.Head);
			Console.WriteLine("    last sector number: {0}", cubicAddress.Sector);
			Console.WriteLine();
			Console.WriteLine("             cylinders: {0}", diskGeometry.Cylinder);
			Console.WriteLine("   tracks per cylinder: {0}", diskGeometry.Head);
			Console.WriteLine("     sectors per track: {0}", diskGeometry.Sector);
			Console.WriteLine();
			Console.WriteLine("      bytes per sector: {0}", diskGeometry.BytesPerSector);
			Console.WriteLine("    bytes per cylinder: {0}", diskGeometry.BytesPerCylinder);
			Console.WriteLine("      total disk space: {0}", diskGeometry.DiskSize);
		}
	}
