    if(sdr.Read()) {
        while (true) {
            ...
            if (!sdr.Read()) {
                break;
            }
            writer.WriteLine("],");  
        }
    }
