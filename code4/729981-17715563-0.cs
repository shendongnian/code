    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                        {
                            Content = new StringContent("Invalid image dimensions. Image file must be " + image.Width + "x" + image.Height + "px"),
                            StatusCode = HttpStatusCode.Forbidden
                        });
