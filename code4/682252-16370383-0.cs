    Console.Write("Input price: ");
                double price;
                string inputPrice = Console.ReadLine();
                if (double.TryParse(inputPrice, out price) && inputPrice.Split('.').Length == 2 && inputPrice.Split('.')[1].Length == 2)
                {
                    price = double.Parse(inputPrice);
                }
                else
                {
                    Console.WriteLine("Inventory code is invalid!");
                }
