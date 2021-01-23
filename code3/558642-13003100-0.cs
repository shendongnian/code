     String Input = Console.Read().ToString().Replace("\r", string.Empty).Replace("\n",string.Empty);
            Console.Write(Input,0,1);
            byte[] inputByte = new byte[1];
            inputByte[0] = Convert.ToByte(Input);
            serialPort.Write(inputByte, 0, 1);
            //byte[] inputByte = Encoding.ASCII.GetBytes(Input);
            //serialPort.Write(inputByte,0,2);
            //String num = inputByte.ToString();
            //serialPort.WriteLine(num);
           //Console.WriteLine(Input);
            //serialPort.Write(InputByte,0,1);
            Thread.Sleep(25);  //Wait 0.025 second.
            //***************************************************************//
            // Read anything from the serial port.                           //
            //***************************************************************//
            numBytes = serialPort.BytesToRead;
            for (int i = 0; i < numBytes; i++)
                rxPacket[i] = (byte)serialPort.ReadByte();
            result = new char[numBytes];
            for (int i = 0; i < numBytes; i++)
                result[i] = (char)rxPacket[i];
            Console.Write("Read this from Arduino:");
            Console.WriteLine(result);
            Console.WriteLine("press Enter to continue");
            Console.ReadKey();                                   //Read nothing.
    Seems to work Perfectly now. 
