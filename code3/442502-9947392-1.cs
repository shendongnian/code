        public static double Average(List<double> argMachineDataList)
        {
            double Total = 0.0;
            int n;
            for (n = 0; n < argMachineDataList.Count; n++)
            {
                Total += argMachineDataList[n]; // added += since you probably want to sum value
            }
            return Total / n;
        }
