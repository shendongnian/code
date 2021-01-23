        [TestMethod]
        public void method_event_expected()
        {
            this.objectUnderTest.TestMethod(
				new KeyEventArgs(Keyboard.PrimaryDevice, new HwndSource(0, 0, 0, 0, 0, "", IntPtr.Zero), 0, Key.Oem3)
				{
					RoutedEvent = Keyboard.KeyDownEvent
				});
			
			Assert.IsTrue(...)
        }
