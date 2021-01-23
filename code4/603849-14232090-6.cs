    private const string filePath = @"d:\test.txt";
    private void LoadFromFile()
    {
        byte[] data = System.IO.File.ReadAllBytes(filePath);
        for (int x = 0; x < btn.GetLength(0); x++)
        {
            for (int y = 0; y < btn.GetLength(1); y++)
            {
                int position = (x * btn.GetLength(1) + y) * 2;
                int index = position / 8;
                int shift = position % 8;
                byte value = (byte)((data[index] >> shift) % 4);
                Color color;
                switch (value)
                {
                    case 1:
                        color = Color.Red;
                        break;
                    case 0:
                        color = Color.Black;
                        break;
                    case 2:
                        color = Color.Green;
                        break;
                    case 3:
                        color = Color.Yellow;
                        break;
                    default:
                        color = Color.Black;
                        break;
                }
                btn[x, y].BackColor = color;
            }
        }
    }
    private void SaveToFile()
    {
        byte[] data = new byte[(7 + btn.GetLength(0) * btn.GetLength(1) * 2) / 8]; 
        for (int x = 0; x < btn.GetLength(0); x++)
        {
            for (int y = 0; y < btn.GetLength(1); y++)
            {
                int position = (x * btn.GetLength(1) + y) * 2;
                byte value;
                switch (btn[x, y].BackColor.Name)
                {
                    case "Red":
                        value = 1;
                        break;
                    case "Black":
                        value = 0;
                        break;
                    case "Green":
                        value = 2;
                        break;
                    case "Yellow":
                        value = 3;
                        break;
                    default:
                        value = 0;
                        break;
                }
                int index = position / 8;
                int shift = position % 8;
                data[index] = (byte)(data[index] | (value << shift));
            }
        }
        System.IO.File.WriteAllBytes(filePath, data);
    }
