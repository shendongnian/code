    try
    {
        using (var writer = File.AppendText("inventory.ini"))
        {
            foreach (Item item in app.array)
            {
                writer.WriteLine(item.Code + "|" + item.Name + "|" + item.Price);
            }
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
