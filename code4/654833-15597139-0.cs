            byte[] buf = new byte[32768 - 10];
            for (; ; )
            {
                long newSize = (long)buf.Length * 2;
                Console.WriteLine(newSize);
                if (newSize > int.MaxValue)
                {
                    Console.WriteLine("Now we reach the max 2Gb per single object, stopping");
                    break;
                }
                var newbuf = new byte[newSize];
                Array.Copy(buf, newbuf, buf.Length);
                buf = newbuf;
            }
