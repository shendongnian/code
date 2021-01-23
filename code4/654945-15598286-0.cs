    private static void MergeSort(int[] array, int size, int index) {
        if (size == 1) {
            return;
        }
        MergeSort(array, size / 2, 0);
        MergeSort(array, size - size / 2, size / 2);
    }
