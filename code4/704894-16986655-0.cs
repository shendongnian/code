    //A RichTextBox with an image.
    private void ImageRTB()
    {
        //Create a new RichTextBox.
        RichTextBox MyRTB = new RichTextBox();
        // Create a Run of plain text and image.
        Run myRun = new Run();
        myRun.Text = "Displaying text with inline image";
        Image MyImage = new Image();
        MyImage.Source = new BitmapImage(new Uri("flower.jpg",    
        UriKind.RelativeOrAbsolute));
        MyImage.Height = 50;
        MyImage.Width = 50;
        InlineUIContainer MyUI = new InlineUIContainer();
        MyUI.Child = MyImage;
        // Create a paragraph and add the paragraph to the RichTextBox.
        Paragraph myParagraph = new Paragraph();
        MyRTB.Blocks.Add(myParagraph);
        // Add the Run and image to it.
        myParagraph.Inlines.Add(myRun);
        myParagraph.Inlines.Add(MyUI);
       //Add the RichTextBox to the StackPanel.
        MySP.Children.Add(MyRTB);
    }
