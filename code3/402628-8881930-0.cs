    Size size = new Size(width, height);
    canvas.Measure(size);
    canvas.Arrange(new Rect(X, Y, width, height));
    //Save Image
    ...  
    ...
    // Revert old position
    canvas.Measure(new Size());
