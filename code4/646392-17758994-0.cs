    // Distances (in µm) where the images were saved
    double[] distance = new double[]
    {
      -50,
      -40,
      -30,
      -20,
      -10,
        0,
      +10,
      +20,
      +30,
      +40,
      +50,
    };
    // Sharpness value of each image, as returned by CalculateFocusValues()
    double[] sharpness = new double[]
    {
      3960.9,
      4065.5,
      4173.0,
      4256.1,
      4317.6,
      4345.4,
      4339.9,
      4301.4,
      4230.0,
      4131.1,
      4035.0,
    };
    // Fit data to y = ax² + bx + c (second degree polynomial) using the Extreme Optimization library
    const int SecondDegreePolynomial = 2;
    Extreme.Mathematics.Curves.LinearCurveFitter fitter = new Extreme.Mathematics.Curves.LinearCurveFitter();
    fitter.Curve = new Extreme.Mathematics.Curves.Polynomial(SecondDegreePolynomial);
    fitter.XValues = new Extreme.Mathematics.LinearAlgebra.GeneralVector(distance,  true);
    fitter.YValues = new Extreme.Mathematics.LinearAlgebra.GeneralVector(sharpness, true);
    fitter.Fit();
    // Find distance of maximum sharpness using the first derivative of the polynomial
    // Using the sample data above, the focus point is located at distance +2.979 µm
    double focusPoint = fitter.Curve.GetDerivative().FindRoots().First();
