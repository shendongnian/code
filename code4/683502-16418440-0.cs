    using (Image<Gray, float> result = source.MatchTemplate(template, Emgu.CV.CvEnum.TM_TYPE.CV_TM_CCOEFF_NORMED))
    {
        double[] minValues, maxValues;
        Point[] minLocations, maxLocations;
        result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
        // You can try different values of the threshold. I guess somewhere between 0.75 and 0.95 would be good.
        if (maxValues[0] > 0.9)
        {
            // This is a match. Do something with it, for example draw a rectangle around it.
            Rectangle match = new Rectangle(maxLocations[0], template.Size);
            source.Draw(match, new Bgr(Color.Red), 3);
        }
    }
