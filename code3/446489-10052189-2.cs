        [TestMethod]
        public void ParseXmlElement()
        {
            XDocument xdoc = XDocument.Parse(this.mockXml);
            XName appTag = XName.Get("{http://tempuri.org/}AppObject");
            XName nameTag = XName.Get("{http://tempuri.org/}Name");
            XName imageTag = XName.Get("{http://tempuri.org/}Image");
            XElement objElement = xdoc.Root.Element(appTag);
            Assert.IsNotNull(objElement, "<AppObject> not found");
            Assert.AreEqual("{http://tempuri.org/}AppObject", objElement.Name);
            XElement nameElement = objElement.Element(nameTag);
            Assert.IsNotNull(nameElement, "<Name> not found");
            Assert.AreEqual("MyApp", nameElement.Value);
            XElement imageElement = objElement.Element(imageTag);
            Assert.IsNotNull(imageElement, "<Image> not found");
            Assert.AreEqual("StoreApp.png", imageElement.Value);
        }
