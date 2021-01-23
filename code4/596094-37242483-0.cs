        YCbCrFiltering YCbCrFilter = new YCbCrFiltering();
        YCbCrFilter.Y = new Range(0, 1);
        YCbCrFilter.Cb = new Range(-0.1862745098039216f, 0.0294117647058824f);
        YCbCrFilter.Cr = new Range(0.0137254901960784f, 0.2254901960784314f);
        // apply the filter
        var YCbCrFilteredImage = YCbCrFilter.Apply(bitmap);
        Grayscale gfilter = new Grayscale(0.2125, 0.7154, 0.0721);
        YCbCrFilteredImage = gfilter.Apply(YCbCrFilteredImage);
        BradleyLocalThresholding thfilter = new BradleyLocalThresholding();
        thfilter.ApplyInPlace(YCbCrFilteredImage);
                
            
