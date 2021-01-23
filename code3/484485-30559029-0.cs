    public bool Checking()
        {
            bool hasDuplicate = false;
            int[] a = new int[] { 1, 2, 3, 4 };
            int[] b = new int[] { 5, 6, 1, 2, 7, 8 };
            int count = a.Intersect(b).Count();
            if (count >= 1)
                hasDuplicate = true;
            return hasDuplicate;
        }
