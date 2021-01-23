    public void SetAllValues(int[,,] data, int value) {
        for (int x = 0; x < data.GetLength(0); x++) {
            for (int y = 0; y < data.GetLength(1); y++) {
                for (int z = 0; z < data.GetLength(2); z++) {
                    data[x, y, z] = value;
                }
            }
        }
    }
