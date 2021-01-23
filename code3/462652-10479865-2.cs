    void webClient_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            DataContractJsonSerializer serializer = null;
            try
            {
                serializer = new DataContractJsonSerializer(typeof(Brands));
                var Brands = (Brands)serializer.ReadObject(e.Result);
                foreach (Brand b in Brands.data)
                {
                    int id = b.CompanyID;
                    string name = b.Name;
                    //listBrands.Items.Add(id + "             " + name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }
