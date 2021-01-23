        public static Texture2D RotateTexture90Deegrees(Texture2D input)
        {
            Texture2D rotated = null;
            if (input != null)
            {
                rotated = new Texture2D(input.GraphicsDevice, input.Width, input.Height);
                Color[] data = new Color[input.Width * input.Height];
                Color[] rotated_data = new Color[data.Length];
                input.GetData<Color>(data);
                var Xcounter = 1;
                var Ycounter = 0;
                for (int i = 0; i < data.Length; i++)
                {
                        rotated_data[i] = data[((input.Width * Xcounter)-1) - Ycounter];
                        Xcounter += 1;
                    if (Xcounter > input.Width)
                    {
                        Xcounter = 1;
                        Ycounter += 1;
                    }
                }
                rotated.SetData<Color>(rotated_data);
            }
            return rotated;
        }
