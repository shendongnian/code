        private void OnHandleHandLeave(object source, HandPointerEventArgs args)
        {
            // This just moves the cursor to the top left corner of the screen.
            // You can handle it differently, but this is just one way.
            System.Drawing.Point mousePt = new System.Drawing.Point(0, 0);
            System.Windows.Forms.Cursor.Position = mousePt;
        }
        private void OnHandleHandMove(object source, HandPointerEventArgs args)
        {
            // The meat of the hand handle method.
            HandPointer ptr = args.HandPointer;
            Point newPoint = kinectRegion.PointToScreen(ptr.GetPosition(kinectRegion));
            clickIfHandIsStable(newPoint); // basically handle a click, not showing code here
            changeMouseCursorPosition(newPoint); // this is where you make the hand and mouse positions the same!
        }
        private void changeMouseCursorPosition(Point newPoint)
        {
            cursorPoint = newPoint;
            System.Drawing.Point mousePt = new System.Drawing.Point((int)cursorPoint.X, (int)cursorPoint.Y);
            System.Windows.Forms.Cursor.Position = mousePt;
        }
