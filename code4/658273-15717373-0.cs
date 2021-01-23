    ImageStatistics stats = new ImageStatistics(sourceImage);
    LevelsLinear levelsLinear = new LevelsLinear {
        InRed = stats.Red.GetRange( 0.90 ),
        InGreen = stats.Green.GetRange( 0.90 ),
        InBlue  = stats.Blue.GetRange( 0.90 )
    };
            
    levelsLinear.ApplyInPlace(sourceImage);
