    // Assuming you have some `List<BonePlacement>` called placements
    public boolean ValidNextMove(BonePlacement placement) {
        if (placements.Count == 0) return true; // presumably the first move is always allowed
        if ((placement.Orientation && BoneOrientation.Horizontal) == BoneOrientation.Horizontal) {
            // The move being tested is a horizontal placement
            if ((placement.Orientation && BoneOrientation.Reversed) == BoneOrientation.Reversed) {
                // The tile is reversed
                // Check for a neighboring tile in an acceptable configuration
            } else {
                // The tile is not reversed
                // Check for a neighboring tile in an acceptable configuration
            }
        } else {
            // The move being tested is a vertical placement
            if ((placement.Orientation && BoneOrientation.Reversed) == BoneOrientation.Reversed) {
                // The tile is reversed
                // Check for a neighboring tile in an acceptable configuration
            } else {
                // The tile is not reversed
                // Check for a neighboring tile in an acceptable configuration
            }
        }
    }
