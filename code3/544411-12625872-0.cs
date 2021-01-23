        [Test]
        public void ElementOfImagesIsNotNull()
        {
            var continuation = _pic.GetImagesAsync().ContinueWith(r =>
            {
                BitmapImage image = r.Result[0];
                image = null;
                Assert.IsNotNull(image);
            });
            // Block until everything finishes, so the test runner sees this correctly!
            continuation.Wait();
        }
