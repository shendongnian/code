    //Must add using System.Reflection; first    
    public class LoginForm : Form {
      public LoginForm(){
         InitializeComponent(); 
         Load += (s,e) => {
            forms = GetAllForms();
            comboBox1.DataSource = forms;
            comboBox1.DisplayMember = "Text";//Show the caption
         }; 
      }
      List<Form> forms;
      public List<Form> GetAllForms(){
        List<Form> forms = new List<Form>();
        foreach (Type t in Assembly.GetExecutingAssembly().GetModules()[0].GetTypes())
        {
          if (t == GetType()) continue;//Don't add LoginForm
          if (t.IsSubclassOf(typeof(Form)))
          {
             forms.Add((Form)t.GetConstructor(Type.EmptyTypes).Invoke(null));
          }
        }
        return forms;
      }
      private void button1_Click(object sender, EventArgs e)
      {
            if (textBox1.Text == username && textBox2.Text == password)
            {
                MessageBox.Show("login successful");
                //Show the selected form
                forms[comboBox1.SelectedIndex].Show();
            }
            else
                MessageBox.Show("wrong password");
      }
    }
