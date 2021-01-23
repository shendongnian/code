        [Test]
        public void TestKeyboardTask()
        {
            KeyboardTask kkt = new KeyboardTask(KeyboardCommand.F1);
            using (MockKeyboardTest f = new MockKeyboardTest())
            {
                f.ShowDialog(kkt);
                Assert.AreEqual(Keys.F1, f.PressedKey);
            }
        }
