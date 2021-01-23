        [TestMethod]
        public void Running_64Bit_OS()
        {
            // It was determined to run only in 64 bits.
            bool is64BitOS = System.Environment.Is64BitOperatingSystem;
            Assert.AreEqual(is64BitOS, true);
        }
        [TestMethod]
        public void Running_64Bit_Process()
        {
            // We have a requirement that one of the unmanaged DLL is built for 64 bits.
            // If you are running MS Test in Visual Studio 2013 and this
            // is failing, go to Test->Test Settings->Default Processor Architecture and
            // chose x64, then run the tests again.  This is not the only method.  You
            // could also use a test settings file.
            bool is64BitProcess = System.Environment.Is64BitProcess;
            Assert.AreEqual(is64BitProcess, true);
        }
