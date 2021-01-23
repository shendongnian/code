    /// <summary>
    /// Returns partition sized which are as close as possible to equal while using the indicated total size available, with any extra distributed to the front
    /// </summary>
    /// <param name="totalSize">The total number of elements to partition</param>
    /// <param name="partitionCount">The number of partitions to size</param>
    /// <param name="remainderAtFront">If true, any remainder will be distributed linearly starting at the beginning; if false, backwards from the end</param>
    /// <returns>An int[] containing the partition sizes</returns>
    public static int[] GetEqualizedPartitionSizes(int totalSize, int partitionCount, bool remainderAtFront = true)
    {
        if (totalSize < 1)
            throw new ArgumentException("Cannot partition a non-positive number (" + totalSize + ")");
        else if (partitionCount < 1)
            throw new ArgumentException("Invalid partition count (" + partitionCount + ")");
        else if (totalSize < partitionCount)
            throw new ArgumentException("Cannot partition " + totalSize + " elements into " + partitionCount + " partitions");
        int[] partitionSizes = new int[partitionCount];
        int basePartitionSize = totalSize / partitionCount;
        int remainder = totalSize % partitionCount;
        int remainderPartitionSize = basePartitionSize + 1;
        int x;
        if (remainderAtFront)
        {
            for (x = 0; x < remainder; x++)
                partitionSizes[x] = remainderPartitionSize;
            for (x = remainder; x < partitionCount; x++)
                partitionSizes[x] = basePartitionSize;
        }
        else
        {
            for (x = 0; x < partitionCount - remainder; x++)
                partitionSizes[x] = basePartitionSize;
            for (x = partitionCount - remainder; x < partitionCount; x++)
                partitionSizes[x] = remainderPartitionSize;
        }
        return partitionSizes;
    }
