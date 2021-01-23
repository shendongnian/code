	internal class AccessibilityTest
	{
		private class Nested
		{
		}
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct NestedStruct
		{
		}
		private enum NestedEnum
		{
			A
		}
		private int Field;
		private void Method()
		{
		}
	}
