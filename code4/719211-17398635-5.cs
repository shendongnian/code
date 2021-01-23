            while (true)
            {
                int k = s.Receive(b);
                Console.WriteLine("\nRecieved...");
                for (int i = 0; i < k; i++)
                {
                    char bc = Convert.ToChar(b[i]); // This is a very wrong way of doing this but it works I guess meh.
                    if (bc == ' ')
                    { // You've struck the end! Get out of this infinite loop!
                        goto endmyloop;
                    }
                    message += bc;
                    Console.Write(bc);
                }
            }
            endmyloop:
