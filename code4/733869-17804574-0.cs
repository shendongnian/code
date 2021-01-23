    //Use ArrayList instead
    private void Form1_Load(object sender, EventArgs e){
      listBox1.DataSource = new System.Collections.ArrayList(Application.OpenForms);
      listBox1.DisplayMember = "Text";
    }
