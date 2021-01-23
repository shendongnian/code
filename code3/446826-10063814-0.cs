        private enum ShipMotionState { NotMoving, MovingLeft, MovingRight };
        private ShipMotionState shipMotion = ShipMotionState.NotMoving;
        protected override void OnKeyDown(KeyEventArgs e) {
            if (e.KeyData == Keys.Left)  shipMotion = ShipMotionState.MovingLeft;
            if (e.KeyData == Keys.Right) shipMotion = ShipMotionState.MovingRight;
            base.OnKeyDown(e);
        }
        protected override void OnKeyUp(KeyEventArgs e) {
            if ((e.KeyData == Keys.Left  && shipMotion == ShipMotionState.MovingLeft) ||
                (e.KeyData == Keys.Right && shipMotion == ShipMotionState.MovingRight) {
                shipMotion = ShipMotionState.NotMoving;
            }
            base.OnKeyUp(e);
        }
        private void GameLoop_Tick(object sender, EventArgs e) {
            if (shipMotion == ShipMotionState.MovingLeft)  spaceShip.MoveLeft();
            if (shipMotion == ShipMotionState.MovingRight) spaceShip.MoveRight();
            // etc..
        }
