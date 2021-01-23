    public static int GetEmployeeCode(string line)
    {
        // Get the substring starting after "Employee code:"
        // ... and stopping at the first space.
        string employeeCode = line.Substring(14).Split(' ')[0];
        int code;
        Int32.TryParse(employeeCode, out code);
        return code;
    }
