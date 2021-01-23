    private static void MergeSort(int[] array, int size, int index) {
        if (size == 1) {
            return;
        }
        MergeSort(array, size / 2, index);
        MergeSort(array, size - size / 2, index + size / 2);
    }
