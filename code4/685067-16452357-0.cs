    System.IO.StreamReader file = new System.IO.StreamReader(myFile);
    while(!file.EndOfStream)
    {
        instancelist[num_instance].Instance_name=file.ReadLine();
        instancelist[num_instance].Instance_stop=file.ReadLine();
        num_instance++;
    }
