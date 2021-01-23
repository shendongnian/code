        int j= 0;
        for (int i = 0; i < p; i++) {
            Console.WriteLine("Page to be inserted: ");
            string x = Console.ReadLine();
            if (frame.Contains(x))
            {
                Console.WriteLine(x + " is a resident page.");
            }
            else {
                if(j >= f)
                    int insertAt = 0;
                else
                    int insertAt = j;
                frame[insertAt ] = x;
                Console.WriteLine("Inserted in frame " + (insertAt + 1) + ". Interrupt generated"));
                interrupt +=1;
                j++;
            }
        }
