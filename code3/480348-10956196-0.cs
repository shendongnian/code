    using tessnet2;
...
    Bitmap image = new Bitmap(@"u:\user files\bwalker\2849257.tif");
                tessnet2.Tesseract ocr = new tessnet2.Tesseract();
                ocr.SetVariable("tessedit_char_whitelist", "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz.,$-/#&=()\"':?"); // Accepted characters
                ocr.Init(@"C:\Users\bwalker\Documents\Visual Studio 2010\Projects\tessnetWinForms\tessnetWinForms\bin\Release\", "eng", false); // Directory of your tessdata folder
                List<tessnet2.Word> result = ocr.DoOCR(image, System.Drawing.Rectangle.Empty);
                string Results = "";
                foreach (tessnet2.Word word in result)
                {
                    Results += word.Confidence + ", " + word.Text + ", " + word.Left + ", " + word.Top + ", " + word.Bottom + ", " + word.Right + "\n";
                }
