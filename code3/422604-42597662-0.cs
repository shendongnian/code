        [TestMethod]
        public void ProjectRejectsGappedVersioningByDefault() {
            var files = new List<ScriptFile>();
            files.Add(ScriptProjectTestMocks.GetVersion1to2());
            files.Add(ScriptProjectTestMocks.GetVersion3to4());
            Assert.Throws<ScriptProject.InvalidProjectFormatException>(() => {
                var sut = new ScriptProject(files);
            });
        }
        [TestMethod]
        public void ProjectAcceptsGappedVersionsExplicitly() {
            var files = new List<ScriptFile>();
            files.Add(ScriptProjectTestMocks.GetVersion1to2());
            files.Add(ScriptProjectTestMocks.GetVersion3to4());
            var sut = new ScriptProject(files, true);
            Assert.IsTrue(true);   // Assert.Pass() would be nicer... build it in if you like
        }
