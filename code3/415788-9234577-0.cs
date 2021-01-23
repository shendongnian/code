        private void MouseDragElementBehavior_DragFinished(object sender, MouseEventArgs e)
        {
            var behavior = (MouseDragElementBehavior)sender;
            System.Diagnostics.Debug.WriteLine("Position: " + behavior.X + " / " + behavior.Y);
        }
