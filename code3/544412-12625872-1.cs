        [TestMethod]
        public async Task ElementOfImagesIsNotNull()
        {
            var images = await _pic.GetImagesAsync();
            BitmapImage image = r.Result[0];
            image = null;
            Assert.IsNotNull(image);
        }
