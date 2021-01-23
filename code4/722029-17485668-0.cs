            const int timeout = 1000;
            const int step = 100;
            for (int t = 0; t < timeout; t += step)
            {
                Thread.Sleep(step);
                if (serialPort1.BytesToRead >= ResponseSize)
                    break;
            }
            
            if (serialPort1.BytesToRead < ResponseSize)
            {
                serialPort1.DiscardInBuffer();
                throw new Exception("Incorrect buffer size!");
            }
            serialPort1.Read(inputData, 0, ResponseSize);
