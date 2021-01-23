    if (image != null)
                    {
                        product.ImageType = image.ContentType;
                        product.Image = new byte[image.ContentLength];
                        image.InputStream.Read(product.Image, 0, image.ContentLength);
                    }
                    else
                    {
                        product.Image = (byte[])Session["image"];
                    }
