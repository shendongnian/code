    using(var reader = new BinaryReader(source)) {
        
        int in = reader.ReadInt32();
        byte[] arr = reader.ReadBytes(32);
        int[] arr2 = new int[4];
        for(int i = 0 ; i < 4 ; i++) arr2[i] = reader.ReadInt32();
        float fl = reader.ReadSingle();
     
        var obj = /* something involving ^^^ */
    }
