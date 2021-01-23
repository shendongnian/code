    int IP1 = 192, IP2 = 168, IP3 = 0, IP4 = 0;
    for (int i1 = IP1; i1 < 256; i1++) {
        for (int i2 = IP2; i2 < 256; i2++) {
            for (int i3 = IP3; i3 < 256; i3++) {
                for (int i4 = IP4; i4 < 256; i4++) {
                    string ip = String.Format("{0}.{1}.{2}.{3}", i1 i2, i3, i4);
                    ...
                }
            }
        }
    }
