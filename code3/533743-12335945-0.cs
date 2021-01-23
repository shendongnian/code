    // ...
    public Soldier Soldier { get; private set; }
    private void button1_Click(object sender, EventArgs e)
    {
      Soldier tempSoldier = new Soldier();
      tempSoldier.surname = textbox1.Text;
      this.Soldier = tempSoldier;
    }
    // ...
