    var carString = new List<string> { "Camaro", "Mini Cooper", "Porsche 944", "Ford Focus", "Chevy Blazer", "Model T", "Camaro", "Mini Cooper", "Porsche 944", "Ford Focus", "Chevy Blazer", "Model T" };
        
        foreach(Control c in Controls)
        {
            if (c is Button)
            {
                Random myRandom = new Random();
                int index = myRandom.Next(carString.Count);
                c.Tag = carString[index];
            }
        }
