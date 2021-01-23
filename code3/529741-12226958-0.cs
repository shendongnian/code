      List<string> Mylist = new List<string>();
                Mylist.Add("salman");
                Mylist.Add("khan");
                Mylist.Add("yousafzai");
                Mylist.Add("ranizai");
                Mylist.Add("kachokhail");
        
            
            
          
                this.tUsersTableAdapter.Fill(this.dbAIASDataSet.tUsers);
                comboBox1.DataSource = Mylist.AsReadOnly();
                comboBox1.DisplayMember = "ID";
                comboBox1.ValueMember = "ID";
            
               comboBox2.DataSource = Mylist.AsReadOnly();
               comboBox2.DisplayMember = "ID";
               comboBox2.ValueMember = "ID";
