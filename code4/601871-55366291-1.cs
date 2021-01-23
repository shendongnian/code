    void canvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                myMatrixTransform.Matrix.Scale(1.1, 1.1);
            }
            else
            {
                myMatrixTransform.Matrix.Scale(1.1, 1.1);
            }
        }
