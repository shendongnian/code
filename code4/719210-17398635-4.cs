            int k = s.Receive(b);
            Console.WriteLine("\nRecieved...");
            for (int i = 0; i < k; i++)
            {
                message += Convert.ToChar(b[i]);
                Console.Write(Convert.ToChar(b[i]));
            }
