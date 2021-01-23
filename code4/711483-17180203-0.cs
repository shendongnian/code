    public static Manager GetBestManager(List<Manager> managerList)
    {
        Manager m = managerList.OrderByDescending(x => x.EmployeesManaged.Count).First();
        return m;
    }
