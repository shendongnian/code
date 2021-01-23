    class MyClass {
        int[] ballSpeedXAxis = new int[10];
        MyClass() { // constructor
           for (int i = 0; i < ballSpeedXAxis.Length; i++)
           {
                ballSpeedXAxis[i] = 1;
           }
        }
        private void OnUpdate(object sender, object e)
        {
            Canvas.SetLeft(this.ball1, this.ballSpeedXAxis[<some index here>] + Canvas.GetLeft(this.ball1));
        }
    }
    
