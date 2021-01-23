        [Test]
        public void GetTrainingById()
        {
            var mockService = MockRepository.GenerateMock<ITrainingService>();
            mockService.Stub(service => service.getTraining(123)).Return(new ImaginaryClass());
            
            var sut = new TrainingController();
            sut.trainingService = mockService;
            var myTrainingView = new MyTrainingView();
            sut.Index(myTrainingView);
            
            Assert.AreEqual(expected, myTrainingView.training);
        }
