    TesseractProcessor ocr = new TesseractProcessor();
    ocr.Init(executionPath, "eng", 3);
    string result = ocr.Apply(bmp);
    Image image = Image.FromFile(imagePath);
    Console.WriteLine(ocr.Apply(image));
    List<tesseract.Word> wordList = ocr.RetriveResultDetail();
