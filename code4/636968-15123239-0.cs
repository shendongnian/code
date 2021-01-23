    var image = System.Drawing.Image.FromFile(@"C:\your\image\here");
            foreach (var a in image.PropertyItems)
            {
                dynamic value;
                switch (a.Type)
                    {
                    case 2:
                        value = Encoding.ASCII.GetString(a.Value);
                        break;
                    case 3:
                        value = BitConverter.ToInt16(a.Value, 0);
                        break;
                    case 4:
                        value = BitConverter.ToInt32(a.Value, 0);
                        break;
                    default:
                        value = "NaN";
                        break;
                    }
             
                Console.WriteLine("Type: {0} \r\n Value: {1}", a.Type, value);
            }
