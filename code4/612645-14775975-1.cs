            var list = new List<Province>();
            string sProvinceName = "";
            string sCityName = "";
            string sPostName = "";
            string sEmployeeFirstName = "";
            string sEmployeeSureName = "";
            var iListListcitys = from province in list
                                 where province != null
                                 where province.Cities != null
                                 where province.ProvinceName == sProvinceName
                                 select province.Cities;
            var iListListposts = from icitys in iListListcitys
                                 from city in icitys
                                 where city != null
                                 where city.ElectricPosts != null
                                 where city.CityName == sCityName
                                 select city.ElectricPosts;
            var iListListEmployees = from posts in iListListposts
                                     from post in posts
                                     where post != null
                                     where post.Employees != null
                                     where post.PostName == sPostName
                                     select post.Employees;
            var listEmployees = from employees in iListListEmployees
                                from employee in employees
                                where employee != null
                                where employee.FirstName == sEmployeeFirstName || employee.SureName == sEmployeeSureName
                                select employee;
            var count = listEmployees.Count();
