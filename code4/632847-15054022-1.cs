    colorString = colorString.Substring(1, colorString.Length - 1);//remove the #
            System.Globalization.NumberStyles style = System.Globalization.NumberStyles.HexNumber;
            int hexColorAsInteger = int.Parse(colorString , style);
            byte[] colorData = BitConverter.GetBytes(hexColorAsInteger);
            //Mind the order.
            byte alpha = colorData[3];
            byte red = colorData[2];
            byte green = colorData[1];
            byte blue = colorData[0];
            Color color = Color.FromArgb(alpha, red, green, blue);
