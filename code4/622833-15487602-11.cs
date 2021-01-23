    [TestClass()]
    public class MyViewModelTest
    {
        [TestMethod()]
        public void DisplayInputDialogCommand_OnExecute_ShowsDialog()
        {
            // Arrange
            Mock<IService> mockService = new Mock<IService>();
            Mock<IDelegateWorker> mockWorker = new Mock<IDelegateWorker>();
            MyViewModel vm = new MyViewModel(mockService.Object, mockWorker.Object);
            InteractionRequestTestHelper<Confirmation> irHelper
                = new InteractionRequestTestHelper<Confirmation>(vm.InputDialogInteractionRequest);
            // Act
            vm.DisplayInputDialogCommand.Execute(null);
            // Assert
            Assert.IsTrue(irHelper.RequestRaised);
        }
        [TestMethod()]
        public void DisplayInputDialogCommand_OnExecute_DialogHasCorrectTitle()
        {
            // Arrange
            const string INPUT_DIALOG_TITLE = "Please provide input...";
            Mock<IService> mockService = new Mock<IService>();
            Mock<IDelegateWorker> mockWorker = new Mock<IDelegateWorker>();
            MyViewModel vm = new MyViewModel(mockService.Object, mockWorker.Object);
            InteractionRequestTestHelper<Confirmation> irHelper
                = new InteractionRequestTestHelper<Confirmation>(vm.InputDialogInteractionRequest);
            // Act
            vm.DisplayInputDialogCommand.Execute(null);
            // Assert
            Assert.AreEqual(irHelper.Title, INPUT_DIALOG_TITLE);
        }
        [TestMethod()]
        public void DisplayInputDialogCommand_OnExecute_SetsIsBusyWhenDialogConfirmed()
        {
            // Arrange
            Mock<IService> mockService = new Mock<IService>();
            Mock<IDelegateWorker> mockWorker = new Mock<IDelegateWorker>();
            MyViewModel vm = new MyViewModel(mockService.Object, mockWorker.Object);
            vm.InputDialogInteractionRequest.Raised += (s, e) =>
            {
                Confirmation context = e.Context as Confirmation;
                context.Confirmed = true;
                e.Callback();
            };
            // Act
            vm.DisplayInputDialogCommand.Execute(null);
            // Assert
            Assert.IsTrue(vm.IsBusy);
        }
        [TestMethod()]
        public void DisplayInputDialogCommand_OnExecute_CallsDoSomethingWhenDialogConfirmed()
        {
            // Arrange
            Mock<IService> mockService = new Mock<IService>();
            IDelegateWorker worker = new DelegateWorker();
            MyViewModel vm = new MyViewModel(mockService.Object, worker);
            vm.InputDialogInteractionRequest.Raised += (s, e) =>
            {
                Confirmation context = e.Context as Confirmation;
                context.Confirmed = true;
                e.Callback();
            };
            // Act
            vm.DisplayInputDialogCommand.Execute(null);
            // Assert
            mockService.Verify(s => s.DoSomething(), Times.Once());
        }
        [TestMethod()]
        public void DisplayInputDialogCommand_OnExecute_ClearsIsBusyWhenDone()
        {
            // Arrange
            Mock<IService> mockService = new Mock<IService>();
            IDelegateWorker worker = new DelegateWorker();
            MyViewModel vm = new MyViewModel(mockService.Object, worker);
            vm.InputDialogInteractionRequest.Raised += (s, e) =>
            {
                Confirmation context = e.Context as Confirmation;
                context.Confirmed = true;
                e.Callback();
            };
            // Act
            vm.DisplayInputDialogCommand.Execute(null);
            // Assert
            Assert.IsFalse(vm.IsBusy);
        }
        [TestMethod()]
        public void DisplayInputDialogCommand_OnExecuteThrowsError_ShowsErrorDialog()
        {
            // Arrange
            Mock<IService> mockService = new Mock<IService>();
            mockService.Setup(s => s.DoSomething()).Throws(new Exception());
            DelegateWorker worker = new DelegateWorker();
            MyViewModel vm = new MyViewModel(mockService.Object, worker);
            vm.InputDialogInteractionRequest.Raised += (s, e) =>
            {
                Confirmation context = e.Context as Confirmation;
                context.Confirmed = true;
                e.Callback();
            };
            InteractionRequestTestHelper<Notification> irHelper
                = new InteractionRequestTestHelper<Notification>(vm.ErrorDialogInteractionRequest);
            // Act
            vm.DisplayInputDialogCommand.Execute(null);
            // Assert
            Assert.IsTrue(irHelper.RequestRaised);
        }
        [TestMethod()]
        public void DisplayInputDialogCommand_OnExecuteThrowsError_ShowsErrorDialogWithCorrectTitle()
        {
            // Arrange
            const string ERROR_TITLE = "Error";
            Mock<IService> mockService = new Mock<IService>();
            mockService.Setup(s => s.DoSomething()).Throws(new Exception());
            DelegateWorker worker = new DelegateWorker();
            MyViewModel vm = new MyViewModel(mockService.Object, worker);
            vm.InputDialogInteractionRequest.Raised += (s, e) =>
            {
                Confirmation context = e.Context as Confirmation;
                context.Confirmed = true;
                e.Callback();
            };
            InteractionRequestTestHelper<Notification> irHelper
                = new InteractionRequestTestHelper<Notification>(vm.ErrorDialogInteractionRequest);
            // Act
            vm.DisplayInputDialogCommand.Execute(null);
            // Assert
            Assert.AreEqual(irHelper.Title, ERROR_TITLE);
        }
        [TestMethod()]
        public void DisplayInputDialogCommand_OnExecuteThrowsError_ShowsErrorDialogWithCorrectErrorMessage()
        {
            // Arrange
            const string ERROR_MESSAGE_TEXT = "do something failed";
            Mock<IService> mockService = new Mock<IService>();
            mockService.Setup(s => s.DoSomething()).Throws(new Exception(ERROR_MESSAGE_TEXT));
            DelegateWorker worker = new DelegateWorker();
            MyViewModel vm = new MyViewModel(mockService.Object, worker);
            vm.InputDialogInteractionRequest.Raised += (s, e) =>
            {
                Confirmation context = e.Context as Confirmation;
                context.Confirmed = true;
                e.Callback();
            };
            InteractionRequestTestHelper<Notification> irHelper
                = new InteractionRequestTestHelper<Notification>(vm.ErrorDialogInteractionRequest);
            // Act
            vm.DisplayInputDialogCommand.Execute(null);
            // Assert
            Assert.AreEqual((string)irHelper.Content, ERROR_MESSAGE_TEXT);
        }
        // Helper Class
        public class InteractionRequestTestHelper<T> where T : Notification
        {
            public bool RequestRaised { get; private set; }
            public string Title { get; private set; }
            public object Content { get; private set; }
            public InteractionRequestTestHelper(InteractionRequest<T> request)
            {
                request.Raised += new EventHandler<InteractionRequestedEventArgs>(
                    (s, e) =>
                    {
                        RequestRaised = true;
                        Title = e.Context.Title;
                        Content = e.Context.Content;
                    });
            }
        }
    }
