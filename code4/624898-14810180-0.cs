    if (image != null) {
    product.ImageMimeType = image.ContentType; 
    product.ImageData = new byte[image.ContentLength];
    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
    }
