    if (rank == 0)
    {
        int all = nTasks-1; //wich is the number of processes -1
    
        while (all > 0)
        {
             Communicator.world.Receive<Pixelator>(Communicator.anySource, 1, out pixelus);
             if (pixelus.x == -1)
             {
                 all--;
             }
        }
    }
    else
    {                    
        for (int i = 0; i < 5; i++)
        {
            Communicator.world.Send<Pixelator>(some_data, 0, 1);
            //Here's the barrier
            Communicator.Barrier();
        }                    
        Communicator.world.Send<Pixelator>(-1, 0, 1);
    }
