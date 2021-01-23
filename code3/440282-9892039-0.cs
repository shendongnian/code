    public partial class Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                btn.Click += new EventHandler(btn_Click);
                
            }
    
            void btn_Click(object sender, EventArgs e)
            {
                Student student = new Student() { Id = 1, Name = "John" };
                int rowsAffected = Student.AddStudent(student);
    
                Response.Write(rowsAffected);
            }
        }
    
    
        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
    
            public static int AddStudent(Student s)
            {
                string conString = System.Configuration.ConfigurationManager.ConnectionStrings["string1"].ConnectionString;
    
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
    
                    SqlCommand cmd = new SqlCommand("INSERT INTO Students (Name) VALUES (@Name)", con);
                    cmd.Parameters.AddWithValue("@Name", s.Name);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
