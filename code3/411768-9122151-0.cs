        void read_one_record(ref int id, ref int stock, ref int published, ref double price, ref string type, ref string title, ref string author)
        {
            StreamReader myFile = File.OpenText("Inventory.dat");
            id = int.Parse(myFile.ReadLine());
            stock = int.Parse(myFile.ReadLine());
            published= int.Parse(myFile.ReadLine());
            stock = int.Parse(myFile.ReadLine());
            price = double.Parse(myFile.ReadLine());
            type = myFile.ReadLine();
            title = myFile.ReadLine();
            author = myFile.ReadLine();
            myFile.Close();
        }
