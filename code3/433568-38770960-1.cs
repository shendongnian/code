    public static IList<Letter> GetDepartmentLettersLinq(int departmentId)
    {
        IEnumerable<Letter> allDepartmentLetters =
            from allLetter in LetterService.GetAllLetters()
            join allUser in UserService.GetAllUsers() on allLetter.EmployeeID equals allUser.ID into usersGroup
            from user in usersGroup.DefaultIfEmpty()// here is the tricky part
            join allDepartment in DepartmentService.GetAllDepartments() on user.DepartmentID equals allDepartment.ID
            where allDepartment.ID == departmentId
            select allLetter;
    
        return allDepartmentLetters.ToArray();
    }
