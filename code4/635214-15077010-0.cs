        /// <summary>
        /// Your test
        ///</summary>
        [TestMethod()]
        [DeploymentItem("YourApplication.exe")]
        public void YourTest()
        {
            //your entry point that you want to call in the exe
            Program_Accessor.YourMethod();
            //Your assert test here
        }
