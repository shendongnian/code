     private void btnUpdateBook_Click(object sender, EventArgs e)
        {
            try
            {
                using(WebClient client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "text/json";                   
                    Uri uri = new Uri(@"http://localhost:8085/BookService/Book");
                    Book updateBook = new Book() { Id = 3, Name = "UpdateBook Name 3", Price = 77.77f };
                    MemoryStream requestStream = new MemoryStream();
                    DataContractJsonSerializer requestSerializer = new DataContractJsonSerializer(typeof(Book));
                    requestSerializer.WriteObject(requestStream, updateBook);
                    client.UploadDataCompleted += OnUpdateBookCompleted;
                    client.UploadDataAsync(uri, "PUT",requestStream.ToArray());
                }
            }
            catch (Exception ex)
            {
            }
        }
        void OnUpdateBookCompleted(object sender, UploadDataCompletedEventArgs e)
        {
            byte[] result = e.Result as byte[];
            MemoryStream responseStream = new MemoryStream(result);
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(IList<Book>));
            IList<Book> books = (IList<Book>)serializer.ReadObject(responseStream);
            bindingSource1.DataSource = books;
            dvBooks.DataSource = bindingSource1;
        }
