    public void remove(string[] listS, int[] listI)
    {
        List<Product> reducedProduct = new List<Product>();
        for(int i = 0; i < listS.Length; i++)
        {
            bool duplicate = false;
            foreach(Product p in reducedProduct)
            {
                if(listS[i].ToLower().Equals(p.Name.ToLower()))
                {
                    p.Quantity += listI[i];
                    duplicate = true;
                    break;
                }
            }
            if(!duplicate)
            {
                Product p;
                p.Name = listS[i];
                p.Quantity = listI[i];
                reducedProduct.Add(a)
            }
        }
        string[] lines = System.IO.File.ReadAllLines("c:\\z.txt");
        for(int i = 0; i < lines.Length; i++)
        {
            string[] linesSplit = lines[i].Split(' ');
            foreach(Product p in reducedProducts)
            {
                if (ingredientDB.ToLower().Equals(p.Name.ToLower()))
                {
                    lines[i] = linesSplit[0] + " " + (int.Parse(linesSplit[1]) - p.Quantity);
                    reducedProducts.Remove(p)
                    break;
                }
            }
        }
        System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\z.txt");
        file.Write(lines);
        file.Close();
    }
