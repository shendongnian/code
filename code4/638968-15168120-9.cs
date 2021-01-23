                        Content = new StringContent(context.Exception.Message),
                        ReasonPhrase = "Exception"
                    });
                }
                //Log Critical errors
                Debug.WriteLine(context.Exception);
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("An error occurred, please try again or contact the administrator."),
                    ReasonPhrase = "Critical Exception"
                });
            }
        }
