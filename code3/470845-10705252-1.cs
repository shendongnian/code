    var myButtons = new List<Button>();
    var btnAdd = new Button();
    btnAdd.Text = dataTable.Rows[i]["deviceDescription"].ToString();
    btnAdd.Location = new Point(x, y);
    btnAdd.Name = i;
    myButtons.Add(btnAdd);
  
    Button foundButton = myButtons.Where(s => s.Name == buttonNumber.ToString());
    
