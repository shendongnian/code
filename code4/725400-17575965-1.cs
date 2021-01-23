            var received = "";
            bool isReading = true;
            while (isReading == true)
            {
                try
                {
                    received += serialPort.ReadExisting();
                    if (received.Contains('>'))
                        isReading = false;
                }
                catch (Exception e)
                {
                }
            }
            Console.WriteLine(received);
