    private readonly string _spionshopConnectionString;
    private void Form1_Load(object sender, EventArgs e)
    {            
        _spionshopConnectionString = ConfigurationManager
              .ConnectionStrings["connSpionshopString"].ConnectionString;
    }
    
    private void button4_Click(object sender, EventArgs e)
    {
        using(var connection = new SqlConnection(_spionshopConnectionString))
        {
             connection.Execute(@"INSERT INTO klant(klant_id,naam,voornaam) 
                                  VALUES (@klantId,@klantNaam,@klantVoornaam)",
                                  new { 
                                          klantId = Convert.ToInt32(textBox1.Text), 
                                          klantNaam = textBox2.Text, 
                                          klantVoornaam = textBox3.Text 
                                      });
        }
    }
