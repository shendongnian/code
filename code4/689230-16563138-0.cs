            var stringBuilder = new StringBuilder();
            bitCounter = 0;
            foreach (bool bit in bitData)
            {                
                if (bit)
                    stringBuilder.Append("█");
                else
                    stringBuilder.Append(" ");
                bitCounter++;
                if (bitCounter > 7)
                {
                    bitCounter = 0;
                    Console.WriteLine(stringBuilder.ToString());
                    stringBuilder.Clear();
                }
            }
