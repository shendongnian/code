     public List<string> A16Games
     {
        get { return this.a16BitGames.OrderBy(x => x).ToList(); }
     }
     public List<string> A8Games
     {
        get { return this.a8BitGames.OrderBy(x => x).ToList(); }
     }
     this.comboBox1.DataSource = this.A16Games;
     this.comboBox2.DataSource = this.A8Games;
