        [TestMethod]
        public void JsonTest()
        {
            string json = "{\"name\":\"ffff\",\"params\":[{\"pId\":1,\"value\":[624,625]},{\"pId\":2,\"value\":\"xxx\"}]}";
            var x = JsonSerializer.DeserializeFromString<xy>(json);
            Assert.AreEqual(x.Params[0].Value.GetType(), typeof(int[]));
            // Show that we have some integers
            Assert.IsTrue(x.Params[0].Value.Count()>0);
        }
