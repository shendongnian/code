    class Enum1
    {
        public class UnderGraduate
        {
            public static string[] EducationUG=new string[]{
                "Bachelor of Arts (B.A)",
                "Bachelor of Arts (Bachelor of Education (B.A. B.Ed)",
                "Bachelor of Arts (Bachelor of Law (B.A.B.L)",
                "Bachelor of Arts (Bachelor of Law (B.A.LLB)",
                "Bachelor of Ayurvedic Medicine and Surgery (B.A.M.S)",
                "Bachelor of Applied Sciences (B.A.S)"}
        }
    }
    private void edulvlcb_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (edulvlcb.SelectedItem.ToString() == "UnderGraduate")
        {         
            educb.Items.Clear();
            foreach (string ug in Enum.UnderGraduate.EducationUG)
                educb.Items.Add(new ListItem(EducationUG[name].ToString()));
        }
    }
