    if(sdr.Read()) {
        while (true) {
            ...
            writer.WriteLine("[");  
            ...
            if (!sdr.Read()) {
                writer.WriteLine("]"); 
                break;
            }
            writer.WriteLine("],");  
        }
    }
