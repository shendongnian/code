        [Test]
        public void TestDevicePresent()
        {
            var bluetoothClassGuid = "e0cbf06c-cd8b-4647-bb8a-263b43f0f974";
            var biometricClassGuid = "53D29EF7-377C-4D14-864B-EB3A85769359";
            var cdromdrivClassGiud = "4d36e965-e325-11ce-bfc1-08002be10318";
            Assert.False(Native.IsDevicePresent(bluetoothClassGuid));
            Assert.False(Native.IsDevicePresent(biometricClassGuid));
            Assert.True(Native.IsDevicePresent(cdromdrivClassGiud));
        }
