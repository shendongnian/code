    int version = 0;
    using (var reader = new ProtoReader(source, RuntimeTypeModel.Default, null))
    {
        int field;
        bool keepReading = true;
        while ((field = reader.ReadFieldHeader()) > 0 && keepReading)
        {   
            switch (field)
            {
                case 12:
                    version = reader.ReadInt32();
                    // STOP LOOPING (leaves the stream partly-read)
                    keepReading = false;
                    break; 
                default:
                    reader.SkipField();
                    break;
            }
        }
    }
