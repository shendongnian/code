        // Save card image
        ImageResizer.SaveImage(CardImg.Image, pics + "\\pics\\" + cardid + ".jpg", 177, 254);
        //Save card thumbnail
        ImageResizer.SaveImage(CardImg.Image, pics + "\\pics\\thumbnail\\" + cardid + ".jpg", 44, 64);
    }
