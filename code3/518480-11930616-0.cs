    string strcommand = string.Empty;
    int num;
    bool result = int.TryParse(txtboxsearch.Text, out num);
    if (result == true)
    {
	strcommand = "SELECT * FROM Emp_Skill_Bridge ESB INNER JOIN  Emp E ON "+
              "E.EmpId = ESB.EmpId INNER JOIN  Skills S ON " +
              "S.SkillID = ESB.SkillID WHERE ESB.SkillID = " + TextBox1.Text ;
    }
    else
    {
        strcommand = "SELECT * FROM Emp_Skill_Bridge ESB INNER JOIN  Emp E " + 
                     "ON E.EmpId = ESB.EmpId INNER JOIN  Skills S ON " +
                     "S.SkillID = ESB.SkillID WHERE ESB.SkillName  like '%" + TextBox1.Text + "%'" ;
    
    }
    SqlCommand cmd = new SqlCommand(strcommand ,con);
