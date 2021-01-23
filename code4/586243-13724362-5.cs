    int personType = 1;
    switch (personType)
    {
        case 1:
        {
            Employee emp = new Employee();
            emp.ExperienceInfo();
            break;
        }
        case 2:
        {
            Employee emp = new Employee(); 
            emp.ManagementInfo();
            break;
        }
        case 3:
        {
            Student st = new Student();
            st.EducationInfo();
            break;
        }
        default:
            MessageBox.Show("Not valid ...");
    }
