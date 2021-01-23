    public static object ChangeSalaryType(int salaryType)
    {
    string salaryTime = string.Empty;
    if (salaryType == 1)
    {
        salaryTime = "per hour";
    }
    else if (salaryType == 2)
    {
        salaryTime = "per week";
    }
    else if (salaryType == 3)
    {
        salaryTime = "per annum";
    }
    return salaryTime;
}
