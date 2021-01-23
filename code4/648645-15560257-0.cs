        [Test]
        public void DeepCopyReturnsSameTypeAsOriginal()
        {
            var iDtoType = typeof (IDto);
            var allIDtoTypes = iDtoType.Assembly.GetTypes().Where(t => iDtoType.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract).ToList();
            foreach (var currentIDtoType in allIDtoTypes)
            {
                var instanceOfDtoType = (IDto)Activator.CreateInstance(currentIDtoType);
                var deepCopyType = instanceOfDtoType.DeepCopy();
                Assert.AreEqual(instanceOfDtoType.GetType(), deepCopyType.GetType(), 
                                    string.Format("Deep Copy of Type '{0}' does not return the same Type. It returns '{1}'. The DeepCopy method of IDto should return the same type.",
                                    instanceOfDtoType.GetType(), deepCopyType.GetType()));
            }
        }
