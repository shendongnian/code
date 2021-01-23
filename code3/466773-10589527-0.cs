    var controller = new ControllerView1();
    var gameView = new GameView1();
    // here we're subscribing to controller's event
    controller.RequestReposition += gameView.UpdatePosition;
    controllersplaceholder.Content = controller;
    gameplaceholder.Content = gameView;
