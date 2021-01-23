    private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
    {
        //Load the files in the Isolated Storage
        var appStorage = IsolatedStorageFile.GetUserStoreForApplication();
        //Retrieve the files
        string[] clientlist = appStorage.GetFileNames();
        foreach (string client in clientlist)
        {
            Cart cart = new Cart { Client = client };
            //Populate the clients list
            clients.Add(cart);
            using (var file = appStorage.OpenFile(client, System.IO.FileMode.Open))
            {
                using (var sr = new StreamReader(file))
                {
                    List<string> cartItems = new List<cartItems>();
          
                    //Retrieve the content of the file
                    string fileContent = sr.ReadToEnd();
                    //Retrieve every item in the file content
                    for (int i = 0 ; i < fileContent.Length ; i += 20)
                    {
                        //Format the file content to the desired format
                        string savedItems = fileContent.Substring(i, 20);
                        savedItems = savedItems.Replace("-", "  ");  // A string is immutable so Replace does not modify savedItems but returns a new string
                        cartItems.Add(savedItems);
                    }
                    cart.Items = cartItems;
                }
            }
            //Populate clientList
            clientList.ItemsSource = clients;
        }
    }
