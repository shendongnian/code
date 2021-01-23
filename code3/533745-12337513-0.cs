    public static Soldier soldier {get;set;}
    private void button1_Click(object sender, EventArgs e)
    {
        soldier = new Soldier();
        soldier.surname = textbox1.text;
    }
