        [TestMethod]
        public void PopulateAreaComboBox_WithValidAreaList()
        {
            //Arrange
            _data = new MockDataRetrieval() { TestDataXml = mockFolderPath + "MockAreaList.xml" };
            _view = new MockMainForm();
            _presenter = new TestCasePresenter(_view, _data);
            //Act
            _presenter.PopulateAreaComboBox();
            //Assert
            Assert.AreEqual(3, _view.AreaListLoaded.Count);
        }
        [TestMethod]
        public void PopulateAreaComboBox_WithEmptyAreaList()
        {
            //Arrange
            _data = new MockDataRetrieval() { TestDataXml = mockFolderPath + "MockEmptyAreaList.xml" };
            _view = new MockMainForm();
            _presenter = new TestCasePresenter(_view, _data);
            //Act
            _presenter.PopulateAreaComboBox();
            //Assert
            Assert.AreEqual(0, _view.AreaListLoaded.Count);
        }
