            [TestMethod]
        public void TestMethod1()
        {
            var tree = new PrefixTree();
            tree.Add("racket".ToCharArray());
            tree.Add("rambo".ToCharArray());
            PrefixTree tree2 = null;
            using (var stream = new MemoryStream())
            {
                Serializer.Serialize(stream, tree);
                stream.Position = 0;
                tree2 = Serializer.Deserialize<PrefixTree>(stream);
            }
            Assert.IsNotNull(tree2);
            Assert.AreEqual(tree._nodes.Count, tree2._nodes.Count);
            Assert.AreEqual(2, tree2._nodes['r']._nodes['a']._nodes.Count);      // 'c' and 'm'
            Assert.AreEqual('c', tree2._nodes['r']._nodes['a']._nodes.Values.First().Value);
            Assert.AreEqual('m', tree2._nodes['r']._nodes['a']._nodes.Values.Last().Value);
        }
