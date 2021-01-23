    static public double[,] Test()
        {
            // This example is for points in 3D.
            // The forth variable is the class label. In this case 2 classes: 0 and 1.
            double[,] xy = new double[,]
            {
            { 4,2,1, 0 }, { 2,4,2, 0 }, { 2,3,3, 0 }, { 3,6,4, 0 }, { 4,4,5, 0 },
            { 9,10,10, 1 }, { 6,8,11, 1 }, { 9,5,12, 1 }, { 8,7,9, 1 }, { 10,8,10, 1 }
            };
            int NPoints = 10;
            int NVars = 3; // 1 for 1 dimension, 2 for 2D and so on...
            int NClasses = 2;
            int info = 0;
            double[,] w = new double[0, 0];
            alglib.lda.fisherldan(xy, NPoints, NVars, NClasses, ref info, ref w);
            return w; // The projection vector/s.
        }
